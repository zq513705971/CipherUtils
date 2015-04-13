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
        /// <summary>
        /// 密钥密文
        /// </summary>
        public string CipherKey;
        private Worker()
        {
        }
        /// <summary>
        /// 创建Worker实例
        /// </summary>
        /// <param name="filePath">Key.key文件路径</param>
        /// <returns></returns>
        public static Worker GetInstance(string filePath)
        {
            if (worker == null)
                worker = new Worker() { CipherKey = LoadKeyFile(filePath) };
            return worker;
        }
        /// <summary>
        /// 导入Key.key文件内容
        /// </summary>
        /// <param name="filePath">Key.key文件路径</param>
        /// <returns>密钥密文</returns>
        public static string LoadKeyFile(string filePath)
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
        /// <summary>
        /// 解密密钥密文
        /// </summary>
        /// <param name="ciphertext">密钥密文</param>
        /// <returns>密钥明文</returns>
        internal static string DecryptKey(string ciphertext)
        {
            AESCode aes = new AESCode() { Key = "ibs.tech" };
            return aes.Decrypt(ciphertext);
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="val">待加密字符串</param>
        /// <returns>密文</returns>
        public string Encrypt(string val)
        {
            AESCode aes = new AESCode() { Key = DecryptKey(this.CipherKey) };
            return aes.Encrypt(val);
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="val">待解密字符串</param>
        /// <returns>明文</returns>
        public string Decrypt(string val)
        {
            AESCode aes = new AESCode() { Key = DecryptKey(this.CipherKey) };
            return aes.Decrypt(val);
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="dt">待加密数据表</param>
        /// <param name="columnIndexs">列序号数组</param>
        /// <returns>加密结果</returns>
        public DataTable Encrypt(DataTable dt, int[] columnIndexs)
        {
            AESCode aes = new AESCode() { Key = DecryptKey(this.CipherKey) };
            return aes.Encrypt(dt, columnIndexs);
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="dt">待解密数据表</param>
        /// <param name="columnIndexs">列序号数组</param>
        /// <returns>解密结果</returns>
        public DataTable Decrypt(DataTable dt, int[] columnIndexs)
        {
            AESCode aes = new AESCode() { Key = DecryptKey(this.CipherKey) };
            return aes.Decrypt(dt, columnIndexs);
        }
        /// <summary>
        /// 加密指定路径的csv文件，默认csv文件包含表头
        /// </summary>
        /// <param name="src">待加密文件路径</param>
        /// <param name="dest">加密后文件路径</param>
        /// <param name="columns">待加密列序号数组</param>
        /// <param name="action">返回false时终止加密操作</param>
        /// <returns>已加密行数</returns>
        public int Encrypt(string src, string dest, int[] columns, Predicate<string> action)
        {
            return Encrypt(src, dest, true, columns, action);
        }
        /// <summary>
        /// 解密指定路径的csv文件，默认csv文件包含表头
        /// </summary>
        /// <param name="src">待解密文件路径</param>
        /// <param name="dest">解密后文件路径</param>
        /// <param name="columns">待解密列序号数组</param>
        /// <param name="action">返回false时终止解密操作</param>
        /// <returns>已解密行数</returns>
        public int Decrypt(string src, string dest, int[] columns, Predicate<string> action)
        {
            return Decrypt(src, dest, true, columns, action);
        }
        /// <summary>
        /// 加密指定路径的csv文件
        /// </summary>
        /// <param name="src">待加密文件路径</param>
        /// <param name="dest">加密后文件路径</param>
        /// <param name="hasHeaders">是否包含列头</param>
        /// <param name="columns">待加密列序号数组</param>
        /// <param name="action">返回false时终止加密操作</param>
        /// <returns>已加密行数</returns>
        public int Encrypt(string src, string dest, bool hasHeaders, int[] columns, Predicate<string> action)
        {
            AESCode aes = new AESCode() { Key = DecryptKey(this.CipherKey) };
            return aes.Encrypt(src, dest, hasHeaders, columns, action);
        }
        /// <summary>
        /// 解密指定路径的csv文件，默认csv文件包含表头
        /// </summary>
        /// <param name="src">待解密文件路径</param>
        /// <param name="dest">解密后文件路径</param>
        /// <param name="hasHeaders">是否包含列头</param>
        /// <param name="columns">待解密列序号数组</param>
        /// <param name="action">返回false时终止解密操作</param>
        /// <returns>已解密行数</returns>
        public int Decrypt(string src, string dest, bool hasHeaders, int[] columns, Predicate<string> action)
        {
            AESCode aes = new AESCode() { Key = DecryptKey(this.CipherKey) };
            return aes.Decrypt(src, dest, hasHeaders, columns, action);
        }
    }
}
