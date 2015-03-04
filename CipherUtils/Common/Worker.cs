using IBS.Data.Csv;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace IBS.Data
{
    public class Worker
    {
        public static DataTable Load(string filePath, int rowCount)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                using (TextReader reader = new StreamReader(filePath, Encoding.Default))
                {
                    CsvReader _reader = new CsvReader(reader, true);
                    DataTable result = new DataTable();
                    foreach (string field in _reader.GetFieldHeaders())
                    {
                        result.Columns.Add(field);
                    }
                    int count = rowCount;
                    while (_reader.ReadNextRecord() && count > 0)
                    {
                        DataRow dr = result.NewRow();
                        object[] objs = new object[_reader.FieldCount];
                        for (int index = 0; index < objs.Length; index++)
                        {
                            objs[index] = _reader[index];
                        }
                        dr.ItemArray = objs;
                        result.Rows.Add(dr);
                        count--;
                    }
                    return result;
                }
            }
            return null;
        }

        public static DataTable Encrypt(DataTable data, string key, DataColumn[] columns)
        {
            return Encrypt(data, key, Array.ConvertAll<DataColumn, int>(columns, (col) => { return col.Ordinal; }));
        }

        public static DataTable Decrypt(DataTable data, string key, DataColumn[] columns)
        {
            return Decrypt(data, key, Array.ConvertAll<DataColumn, int>(columns, (col) => { return col.Ordinal; }));
        }

        public static DataTable Encrypt(DataTable data, string key, int[] columns)
        {
#if RSA
            return RsaCode.RSAEncrypt(key, data, columns);
#elif DES
            return DESCode.DESEncrypt(key, data, columns);
#else
            return AESCode.AESEncrypt(key, data, columns);
#endif
        }

        public static DataTable Decrypt(DataTable data, string key, int[] columns)
        {
#if RSA
            return RsaCode.RSADecrypt(key, data, columns);
#elif DES
            return DESCode.DESDecrypt(key, data, columns);
#else
            return AESCode.AESDecrypt(key, data, columns);
#endif
        }
    }
}
