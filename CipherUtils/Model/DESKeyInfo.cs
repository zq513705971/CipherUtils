using IBS.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;

namespace CipherUtils
{
    public class KeyInfo
    {
        public KeyInfo(DataRow dr)
        {
            this.Key = DESCode.DESDecrypt(dr["key"].ToString(), RsaCode.Prefix);
            this.CreateDate = Convert.ToDateTime(dr["createdate"]);
        }

        public KeyInfo(string key)
        {
            this.CreateDate = DateTime.Now;
            this.Key = key;
        }

        public string Key { get; private set; }
        public DateTime CreateDate { get; set; }
        public bool IsValid { get { return !string.IsNullOrEmpty(this.Key); } }

        private static KeyInfo key;
        public static KeyInfo GetInstance()
        {
            if (KeyInfo.key == null || !KeyInfo.key.IsValid)
            {
                DataTable key = SQLiteDataHelper.GetDataTableBySql("select key,createdate from sy_des_key");
                if (key != null && key.Rows.Count > 0)
                {
                    KeyInfo.key = new KeyInfo(key.Rows[0]);
                    return KeyInfo.key;
                }
                return null;
            }
            else
                return KeyInfo.key;
        }

        public static void Init(KeyInfo key)
        {
            SQLiteDataHelper.ExecuteNonQuery("create table sy_des_key(id integer primary key autoincrement,key varchar(2048),createdate varchar(50),pcname varchar(50))");
            string _key = DESCode.DESEncrypt(key.Key, RsaCode.Prefix);
            SQLiteDataHelper.ExecuteNonQuery(string.Format("insert into sy_des_key(key,createdate,pcname) values('{0}','{1:yyyy-MM-dd HH:mm:ss}','{2}')", _key, key.CreateDate, Dns.GetHostName()));
        }
    }
}
