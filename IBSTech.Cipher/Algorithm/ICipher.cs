using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IBSTech.Cipher
{
    interface ICipher
    {
        string Key { get; set; }

        string Encrypt(string val);

        string Decrypt(string val);

        DataTable Encrypt(DataTable dt, int[] columnIndexs);

        DataTable Decrypt(DataTable dt, int[] columnIndexs);

        int Encrypt(string src, string dest, int[] columns, Predicate<string> action);

        int Decrypt(string src, string dest, int[] columns, Predicate<string> action);

        void GeneralKeyIV(string keyStr, out byte[] key, out byte[] iv);
    }
}
