using IBS.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;

namespace CipherUtils
{
    public class DESKeyInfo
    {
        public DESKeyInfo(DataRow dr)
        {
            this.Key = DESCode.DESDecrypt(dr["key"].ToString(), RsaCode.Prefix);
            this.CreateDate = Convert.ToDateTime(dr["createdate"]);
        }

        public DESKeyInfo(string key)
        {
            this.CreateDate = DateTime.Now;
            this.Key = key;
        }

        public string Key { get; private set; }
        public DateTime CreateDate { get; set; }
        public bool IsValid { get { return !string.IsNullOrEmpty(this.Key); } }

        private static DESKeyInfo key;
        public static DESKeyInfo GetInstance()
        {
            if (DESKeyInfo.key == null || !DESKeyInfo.key.IsValid)
            {
                DataTable key = SQLiteDataHelper.GetDataTableBySql("select key,createdate from sy_des_key");
                if (key != null && key.Rows.Count > 0)
                {
                    DESKeyInfo.key = new DESKeyInfo(key.Rows[0]);
                    return DESKeyInfo.key;
                }
                return null;
            }
            else
                return DESKeyInfo.key;
        }

        public static void Init(DESKeyInfo key)
        {
            SQLiteDataHelper.ExecuteNonQuery("create table sy_des_key(id integer primary key autoincrement,key varchar(2048),createdate varchar(50),pcname varchar(50))");
            string _key = DESCode.DESEncrypt(key.Key, RsaCode.Prefix);
            SQLiteDataHelper.ExecuteNonQuery(string.Format("insert into sy_des_key(key,createdate,pcname) values('{0}','{1:yyyy-MM-dd HH:mm:ss}','{2}')", _key, key.CreateDate, Dns.GetHostName()));
        }
    }
}
