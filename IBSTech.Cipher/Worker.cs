using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace IBSTech.Cipher
{
    public class Worker 
    {
        private static Worker worker;
        public string CipherKey;
        private Worker()
        {
        }

        public static Worker GetInstance(string filePath)
        {
            if (worker == null)
                worker = new Worker() { CipherKey = LoadKeyFile(filePath) };
            return worker;
        }

        internal static string LoadKeyFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    return sr.ReadToEnd();
                }
            }
            return null;
        }

        internal static string DecryptKey(string ciphertext)
        {
            AESCode aes = new AESCode() { Key = "ibs.tech" };
            return aes.Decrypt(ciphertext);
        }

        public string Encrypt(string val)
        {
            AESCode aes = new AESCode() { Key = DecryptKey(this.CipherKey) };
            return aes.Encrypt(val);
        }

        public string Decrypt(string val)
        {
            AESCode aes = new AESCode() { Key = DecryptKey(this.CipherKey) };
            return aes.Decrypt(val);
        }

        public DataTable Encrypt(DataTable dt, int[] columnIndexs)
        {
            AESCode aes = new AESCode() { Key = DecryptKey(this.CipherKey) };
            return aes.Encrypt(dt, columnIndexs);
        }

        public DataTable Decrypt(DataTable dt, int[] columnIndexs)
        {
            AESCode aes = new AESCode() { Key = DecryptKey(this.CipherKey) };
            return aes.Decrypt(dt, columnIndexs);
        }

        public int Encrypt(string src, string dest, int[] columns, Predicate<string> action)
        {
            return Encrypt(src, dest, true, columns, action);
        }

        public int Decrypt(string src, string dest, int[] columns, Predicate<string> action)
        {
            return Decrypt(src, dest, true, columns, action);
        }

        public int Encrypt(string src, string dest, bool hasHeaders, int[] columns, Predicate<string> action)
        {
            AESCode aes = new AESCode() { Key = DecryptKey(this.CipherKey) };
            return aes.Encrypt(src, dest, hasHeaders, columns, action);
        }

        public int Decrypt(string src, string dest, bool hasHeaders, int[] columns, Predicate<string> action)
        {
            AESCode aes = new AESCode() { Key = DecryptKey(this.CipherKey) };
            return aes.Decrypt(src, dest, hasHeaders, columns, action);
        }
    }
}
