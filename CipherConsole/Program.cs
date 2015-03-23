using IBSTech.Cipher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CipherConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("命令格式：\n---type keypath srcpath destpath hasheaders columnIndexs");
                Console.WriteLine("type：\n---e 加密 d 解密");
                Console.WriteLine("keypath：\n---密钥文件路径（Key.key）");
                Console.WriteLine("srcpath/destpath：\n---待加解密文件路径/结果文件路径");
                Console.WriteLine("hasheaders：\n---是否包含列头（1表示包含，0为不包含）");
                Console.WriteLine("columnIndexs：\n---待加解密表格列序号，多列时以“,”分隔");
                Console.WriteLine("如：e C:\\key.key C:\\src.csv C:\\dest.csv 1 1[,2]\n");

                while (true)
                {
                    Console.Write("输入：");
                    string cmd = Console.ReadLine();
                    string[] splits = cmd.Split(' ');
                    if (splits.Length == 6)
                        RunCmd(splits);
                    else
                        Console.WriteLine("命令行错误，请重新输入！");
                }
            }
            else if (args.Length == 6)
                RunCmd(args);
            else
                Console.WriteLine("命令行错误！");
            Console.ReadKey();
        }

        private static void RunCmd(string[] splits)
        {
            try
            {
                bool encrypt = splits[0] == "e";
                bool hasheader = splits[4] == "1";
                string[] cols = splits[5].Split(',');
                string keypath = splits[1];
                string srcpath = splits[2];
                string destpath = splits[3];
                Worker worker = Worker.GetInstance(keypath);
                Console.WriteLine(string.Format("{0:HH:mm:ss} {1}密开始...", DateTime.Now, encrypt ? "加" : "解"));
                if (encrypt)
                    worker.Encrypt(srcpath, destpath, hasheader, Array.ConvertAll<string, int>(cols, (col) => { return Convert.ToInt32(col); }), action);
                else
                    worker.Decrypt(srcpath, destpath, hasheader, Array.ConvertAll<string, int>(cols, (col) => { return Convert.ToInt32(col); }), action);
                Console.WriteLine(string.Format("{0:HH:mm:ss} {1}密结束...", DateTime.Now, encrypt ? "加" : "解"));
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex.Message);
            }
        }

        private static bool action(string val)
        {
            Console.Write("\r" + val);
            return true;
        }
    }
}
