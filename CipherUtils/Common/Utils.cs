using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace IBS.Data
{
    public class Utils
    {
        /// <summary>
        /// 二分法查找
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="obj"></param>
        /// <param name="compare"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static bool BinarySearch<T>(List<T> list, T obj, Comparison<T> compare, out int index)
        {
            int first = 0;
            int ret = 0;
            for (int count = list.Count; count > 0; )
            {
                int count2 = count / 2;
                int mid = first + count2;
                ret = compare(list[mid], obj);
                if (ret < 0)
                {
                    first = mid + 1;
                    count -= count2 + 1;
                }
                else if (ret > 0)
                    count = count2;
                else
                {
                    index = mid;
                    return true;
                }
            }
            index = first;
            return false;
        }

        public static int LowerBound<T>(List<T> list, T obj, Comparison<T> compare)
        {
            int first = 0;
            for (int count = list.Count; count > 0; )
            {
                int count2 = count / 2;
                int mid = first + count2;
                if (compare(list[mid], obj) < 0)
                {
                    first = mid + 1;
                    count -= count2 + 1;
                }
                else
                    count = count2;
            }
            return first;
        }

        /// <summary>
        /// 运行后台操作
        /// </summary>
        /// <param name="backgroundWorker"></param>
        /// <param name="doWork"></param>
        /// <param name="runComplete"></param>
        public static void RunBackgroundWorker(BackgroundWorker backgroundWorker, DoWorkEventHandler doWork, RunWorkerCompletedEventHandler runComplete)
        {
            ClearEventHandler(backgroundWorker, "doWorkKey");
            ClearEventHandler(backgroundWorker, "runWorkerCompletedKey");
            backgroundWorker.WorkerReportsProgress = false;
            backgroundWorker.DoWork += doWork;
            backgroundWorker.RunWorkerCompleted += runComplete;
            backgroundWorker.RunWorkerAsync();
        }

        /// <summary>
        /// 运行后台操作
        /// </summary>
        /// <param name="backgroundWorker"></param>
        /// <param name="doWork"></param>
        /// <param name="reportProgress"></param>
        /// <param name="runComplete"></param>
        public static void RunBackgroundWorker(BackgroundWorker backgroundWorker, DoWorkEventHandler doWork, ProgressChangedEventHandler reportProgress, RunWorkerCompletedEventHandler runComplete)
        {
            ClearEventHandler(backgroundWorker, "doWorkKey");
            ClearEventHandler(backgroundWorker, "progressChangedKey");
            ClearEventHandler(backgroundWorker, "runWorkerCompletedKey");
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.DoWork += doWork;
            backgroundWorker.ProgressChanged += reportProgress;
            backgroundWorker.RunWorkerCompleted += runComplete;
            backgroundWorker.RunWorkerAsync();
        }

        public static void ClearEventHandler(Component obj, string eventName)
        {
            Type t = obj.GetType();
            EventHandlerList eventHandlerList = (EventHandlerList)t.InvokeMember("Events", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetProperty, null, obj, null);
            object key = t.InvokeMember(eventName, BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.GetField, null, null, null);
            Delegate eventDelegate = eventHandlerList[key];
            if (eventDelegate != null)
            {
                foreach (Delegate invocation in eventDelegate.GetInvocationList())
                {
                    eventHandlerList.RemoveHandler(key, invocation);
                }
            }
        }

        public static object InvokeStaticMember(Type type, string methodName)
        {
            return InvokeStaticMember(type, methodName, null);
        }

        public static object InvokeStaticMember(Type type, string methodName, object[] param)
        {
            return type.InvokeMember(methodName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.InvokeMethod, null, null, param);
        }

        /// <summary>
        /// 跨线程设置控件属性值委托类型定义
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="obj"></param>
        /// <param name="methodName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object InvokeMember(BindingFlags flag, object obj, string methodName, object[] value)
        {
            return obj.GetType().InvokeMember(methodName, BindingFlags.Public | BindingFlags.Instance | flag, null, obj, value);
        }

        private delegate object InvokeMemberCallBack(BindingFlags flag, object obj, string methodName, object[] value);
        /// <summary>
        /// 跨线程设置控件属性值委托类型定义
        /// </summary>
        public static object InvokeMember(BindingFlags flag, Control control, string name, object[] value)
        {
            if (control.InvokeRequired == true)
                return control.Invoke(new InvokeMemberCallBack(InvokeMember), new object[] { flag, control, name, value });
            else
                return InvokeMember(flag, (object)control, name, value);
        }

        /// <summary>
        /// 跨线程设置控件属性值
        /// </summary>
        public static void PropertySet(Control control, string name, object value)
        {
            InvokeMember(BindingFlags.SetProperty, control, name, new object[] { value });
        }

        /// <summary>
        /// 跨线程读取控件属性值
        /// </summary>
        public static object PropertyGet(Control control, string name)
        {
            return InvokeMember(BindingFlags.GetProperty, control, name, null);
        }

        public delegate void SimpleCallBack();
        public static void Invoke(Control control, SimpleCallBack func)
        {
            if (control.InvokeRequired)
                control.Invoke(new SimpleCallBack(func));
            else
                func();
        }

        public static TOutput[] ConvertAll<TInput, TOutput>(TInput[] objs, Converter<TInput, TOutput> converter)
        {
            TOutput[] outs = Array.ConvertAll<TInput, TOutput>(objs, converter);
            return outs;
        }
    }
}
