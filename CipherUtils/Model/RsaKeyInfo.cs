using IBS.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Text;

namespace CipherUtils
{
    public class RsaKeyInfo
    {
        public string PublicKey { get; private set; }
        public string PrivateKey { get; private set; }
        public DateTime CreateDate { get; private set; }

        private RsaKeyInfo()
        {
        }

        private RsaKeyInfo(DataRow dr)
        {
#if DES
            this.PublicKey = DESCode.DESDecrypt(dr["publickey"].ToString(), RsaCode.Prefix);
            this.PrivateKey = DESCode.DESDecrypt(dr["privatekey"].ToString(), RsaCode.Prefix);
#else
            this.PublicKey = AESCode.AESDecrypt(dr["publickey"].ToString(), RsaCode.Prefix);
            this.PrivateKey = AESCode.AESDecrypt(dr["privatekey"].ToString(), RsaCode.Prefix);
#endif
            this.CreateDate = Convert.ToDateTime(dr["createdate"]);
        }

        private static RsaKeyInfo Key;
        public static RsaKeyInfo GetInstance()
        {
            if (RsaKeyInfo.Key == null)
            {
                DataTable key = SQLiteDataHelper.GetDataTableBySql("select publickey,privatekey,createdate from sy_key");
                if (key != null && key.Rows.Count > 0)
                {
                    RsaKeyInfo.Key = new RsaKeyInfo(key.Rows[0]);
                    return RsaKeyInfo.Key;
                }
                return null;
            }
            return RsaKeyInfo.Key;
        }

        public static RsaKeyInfo CreateKey()
        {
            string publicKey = null;
            string privateKey = null;
            RsaCode.CreateKey(out publicKey, out privateKey);
            RsaKeyInfo.Key = new RsaKeyInfo() { PublicKey = publicKey, PrivateKey = privateKey, CreateDate = DateTime.Now };
            return RsaKeyInfo.Key;
        }

        public static void Init(RsaKeyInfo key)
        {
            SQLiteDataHelper.ExecuteNonQuery("create table sy_key(id integer primary key autoincrement,publickey varchar(2048),privatekey varchar(2048),createdate varchar(50),pcname varchar(50))");
#if DES
            string _public = DESCode.DESEncrypt(key.PublicKey, RsaCode.Prefix);
            string _private = DESCode.DESEncrypt(key.PrivateKey, RsaCode.Prefix);
#else
            string _public = AESCode.AESEncrypt(key.PublicKey, RsaCode.Prefix);
            string _private = AESCode.AESEncrypt(key.PrivateKey, RsaCode.Prefix);
#endif
            SQLiteDataHelper.ExecuteNonQuery(string.Format("insert into sy_key(publickey,privatekey,createdate,pcname) values('{0}','{1}','{2:yyyy-MM-dd HH:mm:ss}','{3}')", _public, _private, key.CreateDate, Dns.GetHostName()));
        }
    }
}
