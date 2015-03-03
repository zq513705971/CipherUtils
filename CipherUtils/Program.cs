using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace CipherUtils
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.AssemblyResolve += delegate(object sender, ResolveEventArgs senderArgs)
            {
                try
                {
                    Assembly executingAssembly = Assembly.GetExecutingAssembly();
                    string name = new AssemblyName(executingAssembly.FullName).Name;
                    string str = new AssemblyName(senderArgs.Name).Name;
                    if (str.Equals("System.Data.SQLite"))
                    {
                        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "System.Data.SQLite.dll");
                        using (FileStream fs = new FileStream(path, FileMode.CreateNew))
                        {
                            byte[] bytes = Resource.System_Data_SQLite;
                            fs.Write(bytes, 0, bytes.Length);
                        }
                        return Assembly.LoadFrom(path);
                        //return Assembly.Load(Resource.System_Data_SQLite);
                    }
                }
                catch (Exception)
                {
                }
                return null;
            };
            using (Login login = new Login())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new MainForm(login.User));
                }
            }
        }
    }
}
