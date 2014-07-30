using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L_FMS
{
    public class ItemEx
    {
        public decimal PUBLISHMENT_ID { get; set; }
        public decimal ITEM_ID { get; set; }
        public string ITEM_NAME { get; set; }
        public DateTime PUBLISH_DATE { get; set; }
        public string PLACE { get; set; }
    }
    public class PersonMessage
    {
        public string USER_NAME { get; set; }
        public string EMAIL { get; set; }
        public DateTime BIRTH { get; set; }
        public string SEX { get; set; }

    }
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
                USER_ID = this.GetSeqNextVal("user"),
                EMAIL = email,
                PASSWORD = pwd,
                PRIVILEGE = 1,
                VERIFIED = 1
            };

            USERINFO userinfo = new USERINFO
            {
                USERINFO_ID = this.GetSeqNextVal("userinfo"),
                USER_NAME = name,
                PHONE = phone,
                ADDRESS = address,
                MARJOR = major,
                SEX = (sex.Equals("0") ? "M" : "F"),
                BIRTH = DateTime.ParseExact(birth, "yyyy-MM-dd", null)
            };

            USER_USERINFO user_userinfo = new USER_USERINFO
            {
                ID = this.GetSeqNextVal("user_userinfo"),
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

        // 根据Email获取用户User ID
        public decimal GetUserID(string Email)
        {
            decimal userID = -1;

            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    userID = db.ACCOUNT.Where(p => p.EMAIL == Email).FirstOrDefault().USER_ID;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }

            return userID;
        }
        // 获取用户名字
        // 根据User ID获取用户名字
        public string GetUserName(decimal UserId)
        {
            string name = "";

            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    var result = db.Database.SqlQuery<string>("select user_name from account, user_userinfo, userinfo where account.user_id=" + UserId + " and account.user_id=user_userinfo.account and user_userinfo.userinfo=userinfo.userinfo_id").FirstOrDefault();
                    name = result;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }

            return name;
        }

        // 根据Email获取用户名字
        public string GetUserName(string Email)
        {
            string name = "";

            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    var result = db.Database.SqlQuery<string>("select user_name from account, user_userinfo, userinfo where account.email=\'" + Email + "\' and account.user_id=user_userinfo.account and user_userinfo.userinfo=userinfo.userinfo_id").FirstOrDefault();
                    name = result;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }

            return name;
        }

        // 获取用户密码，返回当前时间下加密的MD5值
        // 根据User ID获取密码
        public string GetUserPassword(decimal UserId)
        {
            string pwd = "";

            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    pwd = MD5.EncryptMD5WithRule(db.ACCOUNT.Where(p => p.USER_ID == UserId).FirstOrDefault().PASSWORD);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }

            return pwd;
        }

        // 根据Email获取密码
        public string GetUserPassword(string Email)
        {
            string pwd = "";

            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    pwd = MD5.EncryptMD5WithRule(db.ACCOUNT.Where(p => p.EMAIL == Email).FirstOrDefault().PASSWORD);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }

            return pwd;
        }

        public PUBLISHMENT[] GetPublishment(string keyword)
        {
            PUBLISHMENT[] result;
            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    if (keyword == null)
                    {
                        result = db.PUBLISHMENT.ToArray();
                    }
                    else
                    {
                        string sql = "(select * from PUBLISHMENT where PLACE like \'%"+keyword+"%\') ";
                        result = db.Database.SqlQuery<PUBLISHMENT>(sql).ToArray();
                    }
                    return result;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return null;
        }

        // 获取Item
        // 获取Lost Item
        public ItemEx[] GetLostItem()
        {
            List<ItemEx> result = new List<ItemEx>();
            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    foreach (var i in db.PUBLISHMENT)
                    {
                        // 判断是否为丢失物品
                        if (!i.TYPE.Equals("lost"))
                        {
                            continue;
                        }

                        ItemEx itemEx = new ItemEx
                        {
                            PUBLISHMENT_ID = i.ID,
                            ITEM_ID = i.ITEM_ID,
                            ITEM_NAME = i.ITEM.ITEM_NAME,
                            PUBLISH_DATE = i.PUBLISH_DATE,
                            PLACE = i.PLACE
                        };

                        result.Add(itemEx);
                    }
                    return result.ToArray();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return null;
        }

        // 获取Found Item
        public ItemEx[] GetFoundItem()
        {
            List<ItemEx> result = new List<ItemEx>();
            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    foreach (var i in db.PUBLISHMENT)
                    {
                        // 判断是否为丢失物品
                        if (!i.TYPE.Equals("found"))
                        {
                            continue;
                        }

                        ItemEx itemEx = new ItemEx
                        {
                            PUBLISHMENT_ID = i.ID,
                            ITEM_ID = i.ITEM_ID,
                            ITEM_NAME = i.ITEM.ITEM_NAME,
                            PUBLISH_DATE = i.PUBLISH_DATE,
                            PLACE = i.PLACE
                        };

                        result.Add(itemEx);
                    }
                    return result.ToArray();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return null;
        }
        //根据获得字符查找物品
        public ItemEx[] GetItemBySearchString(string SearchString)
        {
            List<ItemEx> result = new List<ItemEx>();
            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    foreach (var i in db.PUBLISHMENT)
                    {
                        // 判定是否包含要求的字段
                        if (i.ITEM.ITEM_NAME.Contains(SearchString)
                            || i.PUBLISH_DATE.ToString().Contains(SearchString)
                            || i.PLACE.Contains(SearchString))
                        {
                            ItemEx itemEx = new ItemEx
                            {
                                PUBLISHMENT_ID = i.ID,
                                ITEM_ID = i.ITEM_ID,
                                ITEM_NAME = i.ITEM.ITEM_NAME,
                                PUBLISH_DATE = i.PUBLISH_DATE,
                                PLACE = i.PLACE
                            };
                            result.Add(itemEx);
                        }
                        else
                        {
                            //判定tag中是否有相关信息
                            foreach (var j in i.ITEM.ITEM_TAG)
                            {
                                if (j.TAG.TAG_TEXT.Contains(SearchString))
                                {
                            ItemEx itemEx = new ItemEx
                            {
                                PUBLISHMENT_ID = i.ID,
                                ITEM_ID = i.ITEM_ID,
                                ITEM_NAME = i.ITEM.ITEM_NAME,
                                PUBLISH_DATE = i.PUBLISH_DATE,
                                PLACE = i.PLACE
                            };
                            result.Add(itemEx);
                                    break;
                                }
                            }
                        }
                    }
                    return result.ToArray();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return null;
        }

        // 获取account 
        public ACCOUNT[] GetAccountWithSearchString(string USER_EMAIL)
        {
            ACCOUNT[] result;
            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    if (USER_EMAIL == null)
                    {
                        result = db.ACCOUNT.ToArray();
                    }
                    else
                    {
                        result = db.Database.SqlQuery<ACCOUNT>("select * from ACCOUNT where EMAIL like \'%" + USER_EMAIL + "%\'").ToArray();
                    }
                    return result;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message) ;
                }
            }
            return null;
        }
        //根据用户id获得用户信息
        public PersonMessage GetUserMessage(decimal UserId)
        {
            PersonMessage result;
            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    result = db.Database.SqlQuery<PersonMessage>("select user_name,email,birth,sex from account, user_userinfo, userinfo where account.user_id=" + UserId + " and account.user_id=user_userinfo.account and user_userinfo.userinfo=userinfo.userinfo_id").FirstOrDefault();
                    return result;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return null;
        }
        //根据user_id获得用户遗失物品名称

        public string[] GetLostItemByID(decimal user_id)
        {
            List<string> result = new List<string>(); 
            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    foreach (var i in db.PUBLISHMENT)
                    {
                        // 判断是否为丢失物品
                        if (!i.TYPE.Equals("lost")||!i.PUBLISHER_ID.Equals(user_id))
                        {
                            continue;
                        }
                        result.Add(i.ITEM.ITEM_NAME);
                    }
                    return result.ToArray();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return null;
        }
        //根据user_id获得用户的找到的物品
        public string[] GetFoundItemByID(decimal user_id)
        {
            List<string> result = new List<string>(); 
            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    foreach (var i in db.PUBLISHMENT)
                    {
                        // 判断是否为丢失物品
                        if (!i.TYPE.Equals("found")||!i.PUBLISHER_ID.Equals(user_id))
                        {
                            continue;
                        }
                        result.Add(i.ITEM.ITEM_NAME);
                    }
                    return result.ToArray();
            }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return null;
        }

        //获取comments
        public COMMENTS[] GetComments( decimal itemId )
        {
            List<COMMENTS> result = new List<COMMENTS>();
                using (LFMSContext db = new LFMSContext())
                {
                    try
                    {
                        var a=db.COMMENT_ITEM_USER.Where(p => p.ITEM_ID == itemId);
                        foreach( var q in a)
                        {
                            result.Add(q.COMMENTS);
                        }
                        return result.ToArray();
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message) ;
                    }
                }
                return null;
            }

        // 更改对应用户的密码
        public void ResetUserPassword(decimal userID, string newPwd)
        {
            // 加密
            string newPwdMD5 = MD5.Encrypt(newPwd);

            using(LFMSContext db = new LFMSContext())
            {
                try
                {
                    // 获取用户
                    ACCOUNT account = db.ACCOUNT.Where(p => p.USER_ID == userID).FirstOrDefault();

                    account.PASSWORD = newPwdMD5;

                    db.SaveChanges();
                }
                catch(Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
        }
    }

    




    public class PageCuter<ArrayType>
    {

        public PageCuter()
        { 
        }

        //获取inputset指定页;参数 页码:PageNo ; 每页元素个数:NumPerPage ; 数组:inputSet
        //获取第PageNo的内容
        public static ArrayType[] getPage(int PageNo, int NumPerPage, ArrayType[] inputSet)
        {

            ArrayType[] result = null;
            int inputCount = inputSet.Count();
            int inputPageNum = inputCount / NumPerPage;
            
            if (PageNo > inputPageNum) return null;

            int StartP = (PageNo - 1) * NumPerPage;
            int EndP = ((StartP + NumPerPage < inputCount) ? StartP + NumPerPage : inputCount);
            result = new ArrayType[EndP - StartP + 1];

            int j = 0;
            for (int i = StartP; i < EndP; i++, j++)
            {
                //浅拷贝
                result[j] = inputSet[i];
            }
                return result;
        }

    }

}