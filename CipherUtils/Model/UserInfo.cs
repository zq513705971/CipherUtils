using IBS.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CipherUtils
{
    public class UserInfo
    {
        public const string Prefix = "ibs.tech";
        public UserInfo()
        { }

        public UserInfo(DataRow dr)
        {
            this.UserName = dr["username"].ToString();
            this.IsAdmin = Convert.ToInt32(dr["isadmin"]) == 1;
            this.Encrypt = Convert.ToInt32(dr["encrypt"]) == 1;
            this.Decrypt = Convert.ToInt32(dr["decrypt"]) == 1;
#if DES
            this.Password = DESCode.DESDecrypt(dr["password"].ToString(), UserInfo.Prefix);
            string encryptdate = DESCode.DESDecrypt(dr["encryptdate"].ToString(), UserInfo.Prefix);
            string decryptdate = DESCode.DESDecrypt(dr["decryptdate"].ToString(), UserInfo.Prefix);
#else
            this.Password = AESCode.AESDecrypt(dr["password"].ToString(), UserInfo.Prefix);
            string encryptdate = AESCode.AESDecrypt(dr["encryptdate"].ToString(), UserInfo.Prefix);
            string decryptdate = AESCode.AESDecrypt(dr["decryptdate"].ToString(), UserInfo.Prefix);
#endif
            this.EncryptDate = Convert.ToDateTime(encryptdate);
            this.DecryptDate = Convert.ToDateTime(decryptdate);
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public bool IsValid
        {
            get { return (this.Encrypt && this.EncryptDate > DateTime.Now) || (this.Decrypt && this.DecryptDate > DateTime.Now); }
        }

        public bool Encrypt { get; set; }
        public DateTime EncryptDate { get; set; }
        public bool Decrypt { get; set; }
        public DateTime DecryptDate { get; set; }

        public override string ToString()
        {
            return UserName;
        }

        public static bool Init(string password)
        {
            SQLiteDataHelper.ExecuteNonQuery("create table sy_user(id integer primary key autoincrement,username varchar(100),password varchar(100),isadmin integer(5),encrypt integer(5),encryptdate varchar(50),decrypt integer(5),decryptdate varchar(50))");
            UserInfo.Add(new UserInfo() { UserName = "ruiyuan", Password = UserInfo.Prefix, IsAdmin = true, Encrypt = true, EncryptDate = new DateTime(2099, 12, 31), Decrypt = true, DecryptDate = new DateTime(2099, 12, 31) });//最高管理员
            return UserInfo.Add(new UserInfo() { UserName = "administrator", Password = password, IsAdmin = true, Encrypt = true, EncryptDate = new DateTime(2099, 12, 31), Decrypt = true, DecryptDate = new DateTime(2099, 12, 31) });
        }

        public static bool Add(string username, string password, bool isadmin = false, bool encrypt = true, bool decrypt = false)
        {
            return Add(new UserInfo() { UserName = username, Password = password, IsAdmin = isadmin, Encrypt = encrypt, EncryptDate = DateTime.Now.AddMonths(1), Decrypt = decrypt, DecryptDate = DateTime.Now.AddMonths(1) });
        }

        public static bool Add(UserInfo user)
        {
            try
            {
#if DES
                string enpsw = DESCode.DESEncrypt(user.Password, UserInfo.Prefix);
                string encryptdate = DESCode.DESEncrypt(user.EncryptDate.ToString("yyyy-MM-dd HH:mm:ss"), UserInfo.Prefix);
                string decryptdate = DESCode.DESEncrypt(user.DecryptDate.ToString("yyyy-MM-dd HH:mm:ss"), UserInfo.Prefix);
#else
                string enpsw = AESCode.AESEncrypt(user.Password, UserInfo.Prefix);
                string encryptdate = AESCode.AESEncrypt(user.EncryptDate.ToString("yyyy-MM-dd HH:mm:ss"), UserInfo.Prefix);
                string decryptdate = AESCode.AESEncrypt(user.DecryptDate.ToString("yyyy-MM-dd HH:mm:ss"), UserInfo.Prefix);
#endif
                SQLiteDataHelper.ExecuteNonQuery(string.Format("insert into sy_user(username,password,isadmin,encrypt,encryptdate,decrypt,decryptdate) values('{0}','{1}',{2},{3},'{4}',{5},'{6}')", user.UserName, enpsw, user.IsAdmin ? 1 : 0, user.Encrypt ? 1 : 0, encryptdate, user.Decrypt ? 1 : 0, decryptdate));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Update(UserInfo user)
        {
            try
            {
#if DES
                string enpsw = DESCode.DESEncrypt(user.Password, UserInfo.Prefix);
                string encryptdate = DESCode.DESEncrypt(user.EncryptDate.ToString("yyyy-MM-dd HH:mm:ss"), UserInfo.Prefix);
                string decryptdate = DESCode.DESEncrypt(user.DecryptDate.ToString("yyyy-MM-dd HH:mm:ss"), UserInfo.Prefix);
#else
                string enpsw = AESCode.AESEncrypt(user.Password, UserInfo.Prefix);
                string encryptdate = AESCode.AESEncrypt(user.EncryptDate.ToString("yyyy-MM-dd HH:mm:ss"), UserInfo.Prefix);
                string decryptdate = AESCode.AESEncrypt(user.DecryptDate.ToString("yyyy-MM-dd HH:mm:ss"), UserInfo.Prefix);
#endif
                SQLiteDataHelper.ExecuteNonQuery(string.Format("update sy_user set isadmin={0},encrypt={1},encryptdate='{2}',decrypt={3},decryptdate='{4}',password='{5}' where username='{6}'", user.IsAdmin ? 1 : 0, user.Encrypt ? 1 : 0, encryptdate, user.Decrypt ? 1 : 0, decryptdate, enpsw, user.UserName));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Delete(string username)
        {
            try
            {
                SQLiteDataHelper.ExecuteNonQuery(string.Format("delete from sy_user where username='{0}'", username));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool HasUser(string username)
        {
            return SQLiteDataHelper.HasRow(string.Format("select 1 from sy_user where username='{0}'", username));
        }

        public static UserInfo Login(string username, string password, out string msg)
        {
            msg = null;
            try
            {
#if DES
                string enpsw = DESCode.DESEncrypt(password, UserInfo.Prefix);
#else
                string enpsw = AESCode.AESEncrypt(password, UserInfo.Prefix);
#endif
                DataTable users = SQLiteDataHelper.GetDataTableBySql(string.Format("select username,password,isadmin,encrypt,encryptdate,decrypt,decryptdate from sy_user where username='{0}' and password='{1}'", username, enpsw));
                if (users.Rows.Count > 0)
                    return new UserInfo(users.Rows[0]);
                else
                {
                    if (UserInfo.HasUser(username))
                        msg = "密码错误！";
                    else
                        msg = "该用户名不存在！";
                    return null;
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return null;
            }
        }

        public static UserInfo GetUser(string username)
        {
            try
            {
                DataTable users = SQLiteDataHelper.GetDataTableBySql(string.Format("select username,password,isadmin,encrypt,encryptdate,decrypt,decryptdate from sy_user where username='{0}'", username));
                if (users.Rows.Count > 0)
                    return new UserInfo(users.Rows[0]);
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static DataTable GetAllUsers()
        {
            try
            {
                DataTable users = SQLiteDataHelper.GetDataTableBySql("select username USERNAME,password PASSWORD,isadmin ISADMIN,encrypt ENCRYPT,encryptdate ENCRYPTDATE,decrypt DECRYPT,decryptdate DECRYPTDATE from sy_user where id>1");
                if (users != null)
                {
                    DataTable _users = users.Clone();
                    foreach (DataRow dr in users.Rows)
                    {
                        DataRow _dr = _users.NewRow();
                        _dr["USERNAME"] = dr["USERNAME"];
                        _dr["ISADMIN"] = Convert.ToInt32(dr["ISADMIN"]) == 1;
                        _dr["ENCRYPT"] = Convert.ToInt32(dr["ENCRYPT"]) == 1;
                        _dr["DECRYPT"] = Convert.ToInt32(dr["DECRYPT"]) == 1;
#if DES
                        _dr["PASSWORD"] = DESCode.DESDecrypt(dr["PASSWORD"].ToString(), UserInfo.Prefix);
                        _dr["ENCRYPTDATE"] = Convert.ToDateTime(DESCode.DESDecrypt(dr["ENCRYPTDATE"].ToString(), UserInfo.Prefix)).ToString("yyyy-MM-dd");                        
                        _dr["DECRYPTDATE"] = Convert.ToDateTime(DESCode.DESDecrypt(dr["DECRYPTDATE"].ToString(), UserInfo.Prefix)).ToString("yyyy-MM-dd");
#else
                        _dr["PASSWORD"] = AESCode.AESDecrypt(dr["PASSWORD"].ToString(), UserInfo.Prefix);
                        _dr["ENCRYPTDATE"] = Convert.ToDateTime(AESCode.AESDecrypt(dr["ENCRYPTDATE"].ToString(), UserInfo.Prefix)).ToString("yyyy-MM-dd");
                        _dr["DECRYPTDATE"] = Convert.ToDateTime(AESCode.AESDecrypt(dr["DECRYPTDATE"].ToString(), UserInfo.Prefix)).ToString("yyyy-MM-dd");
#endif
                        _users.Rows.Add(_dr);
                    }
                    return _users;
                }
            }
            catch
            {
            }
            return null;
        }
    }
}
