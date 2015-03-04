using IBS.Data.Csv;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace IBS.Data
{
    public class RsaCode
    {
        public const string Prefix = "ibs.tech";
        /// <summary>
        /// 创建RSA公钥和私钥
        /// </summary>
        /// <param name="publicKey"></param>
        /// <param name="privateKey"></param>
        /// <returns></returns>
        public static bool CreateKey(out string publicKey, out string privateKey)
        {
            publicKey = null;
            privateKey = null;
            try
            {
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
#if RSAXML
                    privateKey = rsa.ToXmlString(true);
                    publicKey = rsa.ToXmlString(false);
#else
                    byte[] publicKeyBytes = rsa.ExportCspBlob(false);
                    byte[] privateKeyBytes = rsa.ExportCspBlob(true);
                    publicKey = Convert.ToBase64String(publicKeyBytes);
                    privateKey = Convert.ToBase64String(privateKeyBytes);
#endif
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// RSA加密
        /// </summary>
        /// <param name="publickey"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string RSAEncrypt(string publickey, string content)
        {
            if (string.IsNullOrEmpty(content))
                return null;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                byte[] cipherbytes;
#if RSAXML
                rsa.FromXmlString(publickey);
#else
                byte[] keyBytes = Convert.FromBase64String(publickey);
                rsa.ImportCspBlob(keyBytes);
#endif
                cipherbytes = rsa.Encrypt(Encoding.Unicode.GetBytes(Prefix + content), false);
                return Convert.ToBase64String(cipherbytes);
            }
        }

        /// <summary>
        /// RSA加密
        /// </summary>
        /// <param name="publickey"></param>
        /// <param name="dt"></param>
        /// <param name="columnIndexs"></param>
        /// <returns></returns>
        public static DataTable RSAEncrypt(string publickey, DataTable dt, int[] columnIndexs)
        {
            if (dt == null)
                return null;
            DataTable result = dt.Clone();
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
#if RSAXML
                rsa.FromXmlString(publickey);
#else
                byte[] keyBytes = Convert.FromBase64String(publickey);
                rsa.ImportCspBlob(keyBytes);
#endif
                foreach (DataRow dr in dt.Rows)
                {
                    object[] objs = dr.ItemArray;
                    foreach (int index in columnIndexs)
                    {
                        if (objs[index] != null && objs[index] != DBNull.Value)
                        {
                            byte[] bytes = rsa.Encrypt(Encoding.Unicode.GetBytes(Prefix + objs[index].ToString()), false);
                            objs[index] = Convert.ToBase64String(bytes);
                        }
                    }
                    result.Rows.Add(objs);
                }
            }
            return result;
        }

        /// <summary>
        /// RSA解密
        /// </summary>
        /// <param name="privatekey"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string RSADecrypt(string privatekey, string content)
        {
            if (string.IsNullOrEmpty(content))
                return null;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                byte[] cipherbytes;
#if RSAXML
                rsa.FromXmlString(privatekey);
#else
                byte[] keyBytes = Convert.FromBase64String(privatekey);
                rsa.ImportCspBlob(keyBytes);
#endif
                cipherbytes = rsa.Decrypt(Convert.FromBase64String(content), false);
                string val = Encoding.Unicode.GetString(cipherbytes);
                return val.Substring(Prefix.Length);
            }
        }

        /// <summary>
        ///  RSA解密
        /// </summary>
        /// <param name="privatekey"></param>
        /// <param name="dt"></param>
        /// <param name="columnIndexs"></param>
        /// <returns></returns>
        public static DataTable RSADecrypt(string privatekey, DataTable dt, int[] columnIndexs)
        {
            if (dt == null)
                return null;
            DataTable result = dt.Clone();
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
#if RSAXML
                rsa.FromXmlString(privatekey);
#else
                byte[] keyBytes = Convert.FromBase64String(privatekey);
                rsa.ImportCspBlob(keyBytes);
#endif
                foreach (DataRow dr in dt.Rows)
                {
                    object[] objs = dr.ItemArray;
                    foreach (int index in columnIndexs)
                    {
                        if (objs[index] != null && objs[index] != DBNull.Value)
                        {
                            byte[] bytes = rsa.Decrypt(Convert.FromBase64String(objs[index].ToString()), false);
                            string val = Encoding.Unicode.GetString(bytes);
                            objs[index] = val.Substring(Prefix.Length);
                        }
                    }
                    result.Rows.Add(objs);
                }
            }
            return result;
        }

        public static int RSAEncrypt(string publickey, string src, string dest, int[] columns, Predicate<string> action)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
#if RSAXML
                rsa.FromXmlString(publickey);
#else
                byte[] keyBytes = Convert.FromBase64String(publickey);
                rsa.ImportCspBlob(keyBytes);
#endif
                using (TextReader reader = new StreamReader(src, Encoding.Default))
                {
                    using (TextWriter writer = new StreamWriter(dest, false, Encoding.Default))
                    {
                        CsvReader _reader = new CsvReader(reader, true);
                        int rowIndex = 0;
                        writer.WriteLine(string.Join(",", _reader.GetFieldHeaders()));
                        while (_reader.ReadNextRecord())
                        {
                            if (rowIndex > 0 && rowIndex % 100 == 0 && action != null)
                            {
                                if (!action(string.Format("正在处理第{0}行...", rowIndex)))
                                    break;
                            }
                            string[] objs = new string[_reader.FieldCount];
                            for (int index = 0; index < objs.Length; index++)
                            {
                                if (_reader[index] != null && Array.Exists(columns, (column) => { return Convert.ToInt32(column) == index; }))
                                {
                                    byte[] bytes = rsa.Encrypt(Encoding.Unicode.GetBytes(Prefix + _reader[index].ToString()), false);
                                    objs[index] = Convert.ToBase64String(bytes);
                                }
                                else
                                    objs[index] = _reader[index];
                            }
                            writer.WriteLine(string.Join(",", objs));
                            rowIndex++;
                        }
                        reader.Close();
                        writer.Close();
                        return rowIndex;
                    }
                }
            }
        }

        public static void RSAEncrypt(string publickey, string src, string dest, int[] columns)
        {
            RSAEncrypt(publickey, src, dest, columns, null);
        }

        public static int RSADecrypt(string privatekey, string src, string dest, int[] columns, Predicate<string> action)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
#if RSAXML
                rsa.FromXmlString(privatekey);
#else
                byte[] keyBytes = Convert.FromBase64String(privatekey);
                rsa.ImportCspBlob(keyBytes);
#endif
                using (TextReader reader = new StreamReader(src, Encoding.Default))
                {
                    using (TextWriter writer = new StreamWriter(dest, false, Encoding.Default))
                    {
                        CsvReader _reader = new CsvReader(reader, true);
                        int rowIndex = 0;
                        writer.WriteLine(string.Join(",", _reader.GetFieldHeaders()));
                        while (_reader.ReadNextRecord())
                        {
                            if (rowIndex > 0 && rowIndex % 100 == 0 && action != null)
                            {
                                if (!action(string.Format("正在处理第{0}行...", rowIndex)))
                                    break;
                            }
                            string[] objs = new string[_reader.FieldCount];
                            for (int index = 0; index < objs.Length; index++)
                            {
                                if (_reader[index] != null && Array.Exists(columns, (column) => { return Convert.ToInt32(column) == index; }))
                                {
                                    byte[] bytes = rsa.Decrypt(Convert.FromBase64String(_reader[index].ToString()), false);
                                    string val = Encoding.Unicode.GetString(bytes);
                                    objs[index] = val.Substring(Prefix.Length);
                                }
                                else
                                    objs[index] = _reader[index];
                            }
                            writer.WriteLine(string.Join(",", objs));
                            rowIndex++;
                        }
                        reader.Close();
                        writer.Close();
                        return rowIndex;
                    }
                }
            }
        }

        public static void RSADecrypt(string privatekey, string src, string dest, int[] columns)
        {
            RSADecrypt(privatekey, src, dest, columns, null);
        }
    }

    public class DESCode
    {
        /// <summary>   
        /// 加密方法 
        /// </summary> 
        /// <param name="encryptVal">需要加密字符串</param>
        /// <param name="key">密钥</param>
        /// <returns>加密后的字符串</returns>
        public static string DESEncrypt(string encryptVal, string key)
        {
            if (string.IsNullOrEmpty(encryptVal))
                return null;
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptVal);
                des.Key = ASCIIEncoding.ASCII.GetBytes(key);
                des.IV = ASCIIEncoding.ASCII.GetBytes(key);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(inputByteArray, 0, inputByteArray.Length);
                        cs.FlushFinalBlock();
                        byte[] bytes = (byte[])ms.ToArray();
                        return Convert.ToBase64String(bytes, 0, bytes.Length);
                    }
                }
            }
        }

        /// <summary>   
        /// 解密方法  
        /// </summary>  
        /// <param name="decryptVal">需要解密的字符串</param>   
        /// <param name="key">密匙</param>  
        /// <returns>解密后的字符串</returns> 
        public static string DESDecrypt(string decryptVal, string key)
        {
            if (string.IsNullOrEmpty(decryptVal))
                return null;
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                byte[] inputByteArray = Convert.FromBase64String(decryptVal);
                des.Key = ASCIIEncoding.ASCII.GetBytes(key);
                des.IV = ASCIIEncoding.ASCII.GetBytes(key);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(inputByteArray, 0, inputByteArray.Length);
                        cs.FlushFinalBlock();
                        return Encoding.UTF8.GetString(ms.ToArray());
                    }
                }
            }
        }

        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="publickey"></param>
        /// <param name="dt"></param>
        /// <param name="columnIndexs"></param>
        /// <returns></returns>
        public static DataTable DESEncrypt(string key, DataTable dt, int[] columnIndexs)
        {
            if (dt == null)
                return null;
            DataTable result = dt.Clone();
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = ASCIIEncoding.ASCII.GetBytes(key);
                des.IV = ASCIIEncoding.ASCII.GetBytes(key);
                ICryptoTransform transform = des.CreateEncryptor();
                foreach (DataRow dr in dt.Rows)
                {
                    object[] objs = dr.ItemArray;
                    foreach (int index in columnIndexs)
                    {
                        if (objs[index] != null && objs[index] != DBNull.Value)
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                using (CryptoStream cs = new CryptoStream(ms, transform, CryptoStreamMode.Write))
                                {
                                    byte[] src = Encoding.UTF8.GetBytes(objs[index].ToString());
                                    if (src.Length == 0)
                                        continue;
                                    cs.Write(src, 0, src.Length);
                                    cs.FlushFinalBlock();
                                    byte[] bytes = (byte[])ms.ToArray();
                                    objs[index] = Convert.ToBase64String(bytes);
                                }
                            }
                        }
                    }
                    result.Rows.Add(objs);
                }
            }
            return result;
        }

        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="publickey"></param>
        /// <param name="dt"></param>
        /// <param name="columnIndexs"></param>
        /// <returns></returns>
        public static DataTable DESDecrypt(string key, DataTable dt, int[] columnIndexs)
        {
            if (dt == null)
                return null;
            DataTable result = dt.Clone();
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = ASCIIEncoding.ASCII.GetBytes(key);
                des.IV = ASCIIEncoding.ASCII.GetBytes(key);
                ICryptoTransform transform = des.CreateDecryptor();
                foreach (DataRow dr in dt.Rows)
                {
                    object[] objs = dr.ItemArray;
                    foreach (int index in columnIndexs)
                    {
                        if (objs[index] != null && objs[index] != DBNull.Value)
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                using (CryptoStream cs = new CryptoStream(ms, transform, CryptoStreamMode.Write))
                                {
                                    byte[] src = Convert.FromBase64String(objs[index].ToString());
                                    if (src.Length == 0)
                                        continue;
                                    cs.Write(src, 0, src.Length);
                                    cs.FlushFinalBlock();
                                    byte[] bytes = (byte[])ms.ToArray();
                                    objs[index] = Encoding.UTF8.GetString(ms.ToArray());
                                }
                            }
                        }
                    }
                    result.Rows.Add(objs);
                }
            }
            return result;
        }

        public static int DESEncrypt(string key, string src, string dest, int[] columns, Predicate<string> action)
        {
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = ASCIIEncoding.ASCII.GetBytes(key);
                des.IV = ASCIIEncoding.ASCII.GetBytes(key);
                ICryptoTransform transform = des.CreateEncryptor();
                using (TextReader reader = new StreamReader(src, Encoding.Default))
                {
                    using (TextWriter writer = new StreamWriter(dest, false, Encoding.Default))
                    {
                        CsvReader _reader = new CsvReader(reader, true);
                        int rowIndex = 0;
                        writer.WriteLine(string.Join(",", _reader.GetFieldHeaders()));
                        while (_reader.ReadNextRecord())
                        {
                            if (rowIndex > 0 && rowIndex % 100 == 0 && action != null)
                            {
                                if (!action(string.Format("正在处理第{0}行...", rowIndex)))
                                    break;
                            }
                            string[] objs = new string[_reader.FieldCount];
                            for (int index = 0; index < objs.Length; index++)
                            {
                                if (_reader[index] != null && Array.Exists(columns, (column) => { return Convert.ToInt32(column) == index; }))
                                {
                                    using (MemoryStream ms = new MemoryStream())
                                    {
                                        using (CryptoStream cs = new CryptoStream(ms, transform, CryptoStreamMode.Write))
                                        {
                                            byte[] _bytes = Encoding.UTF8.GetBytes(_reader[index].ToString());
                                            if (_bytes.Length == 0)
                                                continue;
                                            cs.Write(_bytes, 0, _bytes.Length);
                                            cs.FlushFinalBlock();
                                            byte[] bytes = (byte[])ms.ToArray();
                                            objs[index] = Convert.ToBase64String(bytes);
                                        }
                                    }
                                }
                                else
                                    objs[index] = _reader[index];
                            }
                            writer.WriteLine(string.Join(",", objs));
                            rowIndex++;
                        }
                        reader.Close();
                        writer.Close();
                        return rowIndex;
                    }
                }
            }
        }

        public static int DESDecrypt(string key, string src, string dest, int[] columns, Predicate<string> action)
        {
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = ASCIIEncoding.ASCII.GetBytes(key);
                des.IV = ASCIIEncoding.ASCII.GetBytes(key);
                ICryptoTransform transform = des.CreateDecryptor();
                using (TextReader reader = new StreamReader(src, Encoding.Default))
                {
                    using (TextWriter writer = new StreamWriter(dest, false, Encoding.Default))
                    {
                        CsvReader _reader = new CsvReader(reader, true);
                        int rowIndex = 0;
                        writer.WriteLine(string.Join(",", _reader.GetFieldHeaders()));
                        while (_reader.ReadNextRecord())
                        {
                            if (rowIndex > 0 && rowIndex % 100 == 0 && action != null)
                            {
                                if (!action(string.Format("正在处理第{0}行...", rowIndex)))
                                    break;
                            }
                            string[] objs = new string[_reader.FieldCount];
                            for (int index = 0; index < objs.Length; index++)
                            {
                                if (_reader[index] != null && Array.Exists(columns, (column) => { return Convert.ToInt32(column) == index; }))
                                {
                                    using (MemoryStream ms = new MemoryStream())
                                    {
                                        using (CryptoStream cs = new CryptoStream(ms, transform, CryptoStreamMode.Write))
                                        {
                                            byte[] _bytes = Convert.FromBase64String(_reader[index].ToString());
                                            if (_bytes.Length == 0)
                                                continue;
                                            cs.Write(_bytes, 0, _bytes.Length);
                                            cs.FlushFinalBlock();
                                            byte[] bytes = (byte[])ms.ToArray();
                                            objs[index] = Encoding.UTF8.GetString(ms.ToArray());
                                        }
                                    }
                                }
                                else
                                    objs[index] = _reader[index];
                            }
                            writer.WriteLine(string.Join(",", objs));
                            rowIndex++;
                        }
                        reader.Close();
                        writer.Close();
                        return rowIndex;
                    }
                }
            }
        }
    }

    public class AESCode
    {
        private static void GeneralKeyIV(string keyStr, out byte[] key, out byte[] iv)
        {
            byte[] bytes = Encoding.UTF32.GetBytes(keyStr);
            key = SHA256Managed.Create().ComputeHash(bytes);
            iv = MD5.Create().ComputeHash(bytes);
        }

        /// <summary>   
        /// 加密方法 
        /// </summary> 
        /// <param name="encryptVal">需要加密字符串</param>
        /// <param name="key">密钥</param>
        /// <returns>加密后的字符串</returns>
        public static string AESEncrypt(string encryptVal, string key)
        {
            if (string.IsNullOrEmpty(encryptVal))
                return null;
#if CSP
            using (AesCryptoServiceProvider des = new AesCryptoServiceProvider())
#else
            using (AesManaged des = new AesManaged())
#endif
            {
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptVal);
                byte[] _key;
                byte[] _iv;
                GeneralKeyIV(key, out _key, out _iv);
                des.Key = _key;
                des.IV = _iv;
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(inputByteArray, 0, inputByteArray.Length);
                        cs.FlushFinalBlock();
                        byte[] bytes = (byte[])ms.ToArray();
                        return Convert.ToBase64String(bytes, 0, bytes.Length);
                    }
                }
            }
        }

        /// <summary>   
        /// 解密方法  
        /// </summary>  
        /// <param name="decryptVal">需要解密的字符串</param>   
        /// <param name="key">密匙</param>  
        /// <returns>解密后的字符串</returns> 
        public static string AESDecrypt(string decryptVal, string key)
        {
            if (string.IsNullOrEmpty(decryptVal))
                return null;
#if CSP
            using (AesCryptoServiceProvider des = new AesCryptoServiceProvider())
#else
            using (AesManaged des = new AesManaged())
#endif
            {
                byte[] inputByteArray = Convert.FromBase64String(decryptVal);
                byte[] _key;
                byte[] _iv;
                GeneralKeyIV(key, out _key, out _iv);
                des.Key = _key;
                des.IV = _iv;
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(inputByteArray, 0, inputByteArray.Length);
                        cs.FlushFinalBlock();
                        return Encoding.UTF8.GetString(ms.ToArray());
                    }
                }
            }
        }

        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="publickey"></param>
        /// <param name="dt"></param>
        /// <param name="columnIndexs"></param>
        /// <returns></returns>
        public static DataTable AESEncrypt(string key, DataTable dt, int[] columnIndexs)
        {
            if (dt == null)
                return null;
            DataTable result = dt.Clone();
#if CSP
            using (AesCryptoServiceProvider des = new AesCryptoServiceProvider())
#else
            using (AesManaged des = new AesManaged())
#endif
            {
                byte[] _key;
                byte[] _iv;
                GeneralKeyIV(key, out _key, out _iv);
                des.Key = _key;
                des.IV = _iv;
                ICryptoTransform transform = des.CreateEncryptor();
                foreach (DataRow dr in dt.Rows)
                {
                    object[] objs = dr.ItemArray;
                    foreach (int index in columnIndexs)
                    {
                        if (objs[index] != null && objs[index] != DBNull.Value)
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                using (CryptoStream cs = new CryptoStream(ms, transform, CryptoStreamMode.Write))
                                {
                                    byte[] src = Encoding.UTF8.GetBytes(objs[index].ToString());
                                    if (src.Length == 0)
                                        continue;
                                    cs.Write(src, 0, src.Length);
                                    cs.FlushFinalBlock();
                                    byte[] bytes = (byte[])ms.ToArray();
                                    objs[index] = Convert.ToBase64String(bytes);
                                }
                            }
                        }
                    }
                    result.Rows.Add(objs);
                }
            }
            return result;
        }

        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="publickey"></param>
        /// <param name="dt"></param>
        /// <param name="columnIndexs"></param>
        /// <returns></returns>
        public static DataTable AESDecrypt(string key, DataTable dt, int[] columnIndexs)
        {
            if (dt == null)
                return null;
            DataTable result = dt.Clone();
#if CSP
            using (AesCryptoServiceProvider des = new AesCryptoServiceProvider())
#else
            using (AesManaged des = new AesManaged())
#endif
            {
                byte[] _key;
                byte[] _iv;
                GeneralKeyIV(key, out _key, out _iv);
                des.Key = _key;
                des.IV = _iv;
                ICryptoTransform transform = des.CreateDecryptor();
                foreach (DataRow dr in dt.Rows)
                {
                    object[] objs = dr.ItemArray;
                    foreach (int index in columnIndexs)
                    {
                        if (objs[index] != null && objs[index] != DBNull.Value)
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                using (CryptoStream cs = new CryptoStream(ms, transform, CryptoStreamMode.Write))
                                {
                                    byte[] src = Convert.FromBase64String(objs[index].ToString());
                                    if (src.Length == 0)
                                        continue;
                                    cs.Write(src, 0, src.Length);
                                    cs.FlushFinalBlock();
                                    byte[] bytes = (byte[])ms.ToArray();
                                    objs[index] = Encoding.UTF8.GetString(ms.ToArray());
                                }
                            }
                        }
                    }
                    result.Rows.Add(objs);
                }
            }
            return result;
        }

        public static int AESEncrypt(string key, string src, string dest, int[] columns, Predicate<string> action)
        {
#if CSP
            using (AesCryptoServiceProvider des = new AesCryptoServiceProvider())
#else
            using (AesManaged des = new AesManaged())
#endif
            {
                byte[] _key;
                byte[] _iv;
                GeneralKeyIV(key, out _key, out _iv);
                des.Key = _key;
                des.IV = _iv;
                ICryptoTransform transform = des.CreateEncryptor();
                using (TextReader reader = new StreamReader(src, Encoding.Default))
                {
                    using (TextWriter writer = new StreamWriter(dest, false, Encoding.Default))
                    {
                        CsvReader _reader = new CsvReader(reader, true);
                        int rowIndex = 0;
                        writer.WriteLine(string.Join(",", _reader.GetFieldHeaders()));
                        while (_reader.ReadNextRecord())
                        {
                            if (rowIndex > 0 && rowIndex % 100 == 0 && action != null)
                            {
                                if (!action(string.Format("正在处理第{0}行...", rowIndex)))
                                    break;
                            }
                            string[] objs = new string[_reader.FieldCount];
                            for (int index = 0; index < objs.Length; index++)
                            {
                                if (_reader[index] != null && Array.Exists(columns, (column) => { return Convert.ToInt32(column) == index; }))
                                {
                                    using (MemoryStream ms = new MemoryStream())
                                    {
                                        using (CryptoStream cs = new CryptoStream(ms, transform, CryptoStreamMode.Write))
                                        {
                                            byte[] _bytes = Encoding.UTF8.GetBytes(_reader[index].ToString());
                                            if (_bytes.Length == 0)
                                                continue;
                                            cs.Write(_bytes, 0, _bytes.Length);
                                            cs.FlushFinalBlock();
                                            byte[] bytes = (byte[])ms.ToArray();
                                            objs[index] = Convert.ToBase64String(bytes);
                                        }
                                    }
                                }
                                else
                                    objs[index] = _reader[index];
                            }
                            writer.WriteLine(string.Join(",", objs));
                            rowIndex++;
                        }
                        reader.Close();
                        writer.Close();
                        return rowIndex;
                    }
                }
            }
        }

        public static int AESDecrypt(string key, string src, string dest, int[] columns, Predicate<string> action)
        {
#if CSP
            using (AesCryptoServiceProvider des = new AesCryptoServiceProvider())
#else
            using (AesManaged des = new AesManaged())
#endif
            {
                byte[] _key;
                byte[] _iv;
                GeneralKeyIV(key, out _key, out _iv);
                des.Key = _key;
                des.IV = _iv;
                ICryptoTransform transform = des.CreateDecryptor();
                using (TextReader reader = new StreamReader(src, Encoding.Default))
                {
                    using (TextWriter writer = new StreamWriter(dest, false, Encoding.Default))
                    {
                        CsvReader _reader = new CsvReader(reader, true);
                        int rowIndex = 0;
                        writer.WriteLine(string.Join(",", _reader.GetFieldHeaders()));
                        while (_reader.ReadNextRecord())
                        {
                            if (rowIndex > 0 && rowIndex % 100 == 0 && action != null)
                            {
                                if (!action(string.Format("正在处理第{0}行...", rowIndex)))
                                    break;
                            }
                            string[] objs = new string[_reader.FieldCount];
                            for (int index = 0; index < objs.Length; index++)
                            {
                                if (_reader[index] != null && Array.Exists(columns, (column) => { return Convert.ToInt32(column) == index; }))
                                {
                                    using (MemoryStream ms = new MemoryStream())
                                    {
                                        using (CryptoStream cs = new CryptoStream(ms, transform, CryptoStreamMode.Write))
                                        {
                                            byte[] _bytes = Convert.FromBase64String(_reader[index].ToString());
                                            if (_bytes.Length == 0)
                                                continue;
                                            cs.Write(_bytes, 0, _bytes.Length);
                                            cs.FlushFinalBlock();
                                            byte[] bytes = (byte[])ms.ToArray();
                                            objs[index] = Encoding.UTF8.GetString(ms.ToArray());
                                        }
                                    }
                                }
                                else
                                    objs[index] = _reader[index];
                            }
                            writer.WriteLine(string.Join(",", objs));
                            rowIndex++;
                        }
                        reader.Close();
                        writer.Close();
                        return rowIndex;
                    }
                }
            }
        }
    }
}
