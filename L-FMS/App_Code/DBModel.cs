using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L_FMS
{
    public class DBModel
    {
        // 单例
        private static DBModel dbModel;

        // 私有构造函数
        private DBModel()
        {
            
        }

        public static DBModel GetInstance()
        {
            if (dbModel == null)
            {
                dbModel = new DBModel();
            }
            return dbModel;
        }

        // 操作
        // 获取序列下一个值
        public decimal GetSeqNextVal(string table)
        {
            decimal result = 0;
            using(LFMSContext db = new LFMSContext())
            {
                string seq = table + "_increment_seq.nextval";

                var l = db.Database.SqlQuery<decimal>("select " + seq + " from dual").ToList();

                foreach (var n in l)
                {
                    result = n;
                    break;
                }
            }
            return result;
        }

        // 注册新用户
        public void RegisterNewUser(ACCOUNT account, USERINFO userinfo)
        {
            USER_USERINFO user_userinfo = new USER_USERINFO
            {
                ID = DBModel.GetInstance().GetSeqNextVal("user_userinfo"),
                ACCOUNT = account.USER_ID,
                USERINFO = userinfo.USERINFO_ID
            };

            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    db.ACCOUNT.Add(account);
                    db.USERINFO.Add(userinfo);
                    db.USER_USERINFO.Add(user_userinfo);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Unique");
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
        }

        public void RegisterNewUser(HttpRequest Request)
        {
            string email = Request.Form["email"];
            string pwd = Request.Form["pwd"];
            string pwdValidate = Request.Form["pwd-validate"];

            if (pwd.Equals(pwdValidate))
            {
                pwd = MD5.Encrypt(pwd);
            }

            string name = Request.Form["user-name"];
            string phone = Request.Form["phone"];
            string address = Request.Form["address"];
            string major = Request.Form["major"];
            string sex = Request.Form["sex"];
            string birth = Request.Form["birth"];

            ACCOUNT account = new ACCOUNT
            {
                USER_ID = DBModel.GetInstance().GetSeqNextVal("user"),
                EMAIL = email,
                PASSWORD = pwd,
                PRIVILEGE = 1,
                VERIFIED = 1
            };

            USERINFO userinfo = new USERINFO
            {
                USERINFO_ID = DBModel.GetInstance().GetSeqNextVal("userinfo"),
                USER_NAME = name,
                PHONE = phone,
                ADDRESS = address,
                MARJOR = major,
                SEX = (sex.Equals("0") ? "M" : "F"),
                BIRTH = DateTime.ParseExact(birth, "yyyy-MM-dd", null)
            };

            USER_USERINFO user_userinfo = new USER_USERINFO
            {
                ID = DBModel.GetInstance().GetSeqNextVal("user_userinfo"),
                ACCOUNT = account.USER_ID,
                USERINFO = userinfo.USERINFO_ID
            };

            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    db.ACCOUNT.Add(account);
                    db.USERINFO.Add(userinfo);
                    db.USER_USERINFO.Add(user_userinfo);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Unique");
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
        }
    }
}