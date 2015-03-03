using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Reflection;
using System.IO;
using System.Data;

namespace IBS.Data
{
    /// <summary>
    /// 工具类
    /// </summary>
    public class FileHelper
    {
        /// <summary>
        /// 写内容到文件中
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="content">内容</param>
        public static void WriteToTxt(string filePath, string content)
        {
            WriteToTxt(filePath, null, null, new List<string>() { content }, Encoding.Default);
        }

        /// <summary>
        /// 写内容到文件中
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="content">内容</param>
        /// <param name="deleteOld">删除旧文件</param>
        public static void WriteToTxt(string filePath, string content, bool deleteOld)
        {
            WriteToTxt(filePath, null, null, new List<string>() { content }, Encoding.Default, deleteOld);
        }

        /// <summary>
        /// 写内容到文件中
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="content">内容</param>
        /// <param name="encoding">字符编码</param>
        public static void WriteToTxt(string filePath, string content, Encoding encoding)
        {
            WriteToTxt(filePath, null, null, new List<string>() { content }, encoding);
        }

        /// <summary>
        /// 写内容到文件中
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="contents">内容</param>
        /// <param name="encoding">字符编码</param>
        public static void WriteToTxt(string filePath, List<string> contents, Encoding encoding)
        {
            WriteToTxt(filePath, null, null, contents, encoding);
        }

        /// <summary>
        /// 写内容到文件中
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="contents">内容</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="deleteOld">删除旧文件</param>
        public static void WriteToTxt(string filePath, List<string> contents, bool deleteOld)
        {
            WriteToTxt(filePath, null, null, contents, Encoding.Default, deleteOld);
        }

        /// <summary>
        /// 写内容到文件中
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="content">内容</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="deleteOld">删除旧文件</param>
        public static void WriteToTxt(string filePath, string content, Encoding encoding, bool deleteOld)
        {
            WriteToTxt(filePath, null, null, new List<string>() { content }, encoding, deleteOld);
        }

        /// <summary>
        /// 写内容到文件中
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="contents">内容</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="deleteOld">删除旧文件</param>
        public static void WriteToTxt(string filePath, List<string> contents, Encoding encoding, bool deleteOld)
        {
            WriteToTxt(filePath, null, null, contents, encoding, deleteOld);
        }

        /// <summary>
        /// 写内容到文件中
        /// </summary>
        /// <param name="fileName">文件名（不包括后缀名）</param>
        /// <param name="suffix">拓展</param>
        /// <param name="extension">后缀</param>
        /// <param name="contents">内容</param>
        /// <param name="encoding">字符编码</param>
        public static void WriteToTxt(string fileName, string suffix, string extension, List<string> contents, Encoding encoding)
        {
            WriteToTxt(fileName, suffix, extension, contents, encoding, false);
        }

        /// <summary>
        /// 写内容到文件中
        /// </summary>
        /// <param name="fileName">文件名（不包括后缀名）</param>
        /// <param name="suffix">拓展</param>
        /// <param name="extension">后缀</param>
        /// <param name="contents">内容</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="deleteOld">删除旧文件</param>
        public static void WriteToTxt(string fileName, string suffix, string extension, List<string> contents, Encoding encoding, bool deleteOld)
        {
            string filePath = string.Format("{0}{1}{2}", fileName, suffix, extension);
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            }
            if (deleteOld && File.Exists(filePath))
                File.Delete(filePath);
            using (FileStream mystream = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.None))
            {
                using (StreamWriter sw = new StreamWriter(mystream, encoding))
                {
                    try
                    {
                        foreach (string info in contents)
                            sw.WriteLine(info);
                        sw.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        contents = null;
                    }
                }
            }
        }

        /// <summary>
        /// 默认字符编码读取txt文件内容
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public static string TxtReader(string filePath)
        {
            return TxtReader(filePath, Encoding.Default);
        }

        /// <summary>
        /// 读指定txt文件文件内容
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="encoding">字符编码</param>
        /// <returns></returns>
        public static string TxtReader(string filePath, Encoding encoding)
        {
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath, encoding))
                    return sr.ReadToEnd();
            }
            throw new Exception("文件不存在");
        }

        /// <summary>
        /// 读取txt文件中的行到List中
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public static List<string> TxtListReader(string filePath)
        {
            return TxtListReader(filePath, Encoding.Default);
        }

        /// <summary>
        /// 读取txt文件中的行到List中
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="encoding">字符编码</param>
        /// <returns></returns>
        public static List<string> TxtListReader(string filePath, Encoding encoding)
        {
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath, encoding))
                {
                    List<string> lines = new List<string>();
                    string info = sr.ReadLine();
                    while (info != null)
                    {
                        lines.Add(info);
                        info = sr.ReadLine();
                    }
                    return lines;
                }
            }
            throw new Exception("文件不存在");
        }

        public static void Save(DataTable dataTable, string filePath)
        {
            string[] cols = new string[dataTable.Columns.Count];
            for (int i = 0; i < cols.Length; ++i)
                cols[i] += dataTable.Columns[i].ColumnName;
            Save(dataTable, string.Concat("\"", string.Join("\",\"", cols), "\""), filePath);
        }

        public static void Save(DataTable dataTable, string columns, string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath, false, System.Text.Encoding.Default, 128 * 1024))
            {
                sw.WriteLine(columns);
                string[] cols = new string[dataTable.Columns.Count];
                foreach (DataRow row in dataTable.Rows)
                {
                    for (int i = 0; i < cols.Length; ++i)
                        cols[i] = row.ItemArray[i].ToString();
                    sw.Write('\"');
                    sw.Write(string.Join("\",\"", cols));
                    sw.Write("\"\n");
                }
                sw.Close();
            }
        }

        public static void Save(DataTable dataTable, int rowCount, string columns, string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath, false, System.Text.Encoding.Default, 128 * 1024))
            {
                sw.WriteLine(columns);
                string[] cols = new string[dataTable.Columns.Count];
                foreach (DataRow row in dataTable.Rows)
                {
                    if (rowCount-- == 0)
                        break;
                    for (int i = 0; i < cols.Length; ++i)
                        cols[i] = row.ItemArray[i].ToString();
                    sw.Write('\"');
                    sw.Write(string.Join("\",\"", cols));
                    sw.Write("\"\n");
                }
                sw.Close();
            }
        }

        public static void Save(DataRow[] rows, int rowCount, int columnCount, string columns, string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath, false, System.Text.Encoding.Default, 128 * 1024))
            {
                sw.WriteLine(columns);
                string[] cols = new string[columnCount];
                foreach (DataRow row in rows)
                {
                    if (rowCount-- == 0)
                        break;
                    for (int i = 0; i < cols.Length; ++i)
                        cols[i] = row.ItemArray[i].ToString();
                    sw.Write('\"');
                    sw.Write(string.Join("\",\"", cols));
                    sw.Write("\"\n");
                }
                sw.Close();
            }
        }
    }
}
