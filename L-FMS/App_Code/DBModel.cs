using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace L_FMS
{
    public class UserOrdered
    {
        public decimal publisher_id { get; set; }
        public decimal tot { get; set; }
    }
    public class Dialog_Name
    {
        public decimal DIALOG_ID { get; set; }
        public string CONTACT_NAME { get; set; }
    }
    public class ItemEx
    {
        public decimal PUBLISHMENT_ID { get; set; }
        public decimal ITEM_ID { get; set; }
        public string ITEM_NAME { get; set; }
        public DateTime PUBLISH_DATE { get; set; }
        public string PLACE { get; set; }
    }
    public class PersonAllMessage
    {
        public string USER_NAME { get; set; }
        public string EMAIL { get; set; }
        public DateTime BIRTH { get; set; }
        public string SEX { get; set; }
        public string phone{ get; set;}
        public string marjor{ get; set;}
        public string address { get; set; }

    }
    public class User_Comment
    {
        public string user_name { get; set; }
        public string content { get; set; }
        public DateTime time { get; set; }
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
            using (LFMSContext db = new LFMSContext())
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

        //获得拾金不昧排行榜
        public UserOrdered[] GetUserOrdered()
        {
            UserOrdered[] result;
            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    string sql = "select publisher_id, tot from (select publisher_id,count(ID) as tot from publishment where type = \'found\' group by publisher_id  ) order by tot  desc";
                    result = db.Database.SqlQuery<UserOrdered>(sql).ToArray();
                    return result;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return null;
        }

        //判断用户是否设置了密保问题
        public Boolean SecurityQuestion(Decimal userid)
        {
            LFMSContext db = new LFMSContext();
            string sql = "select * from USER_QUESTION where USER_ID = " + userid;
            var result = db.Database.SqlQuery<USER_QUESTION>(sql).ToArray();
            if (result.Length == 0)
                return false;
            return true;
        }

        //返回用户设置的密保问题
        public QUESTION[] GetSecurityQuesion(Decimal userid)
        {
            QUESTION[] questions;
            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    string sql = "select * from QUESTION where QUESTION_ID in (select QUESTION_ID from USER_QUESTION where USER_ID = " + userid +" )";
                    questions = db.Database.SqlQuery<QUESTION>(sql).ToArray();
                    return questions;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return null;
        }


        //通过ID获得密保问题
        public QUESTION GetSecurityQuesionByID(Decimal questionid)
        {
            QUESTION question;
            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    question = db.QUESTION.Where(p => p.QUESTION_ID == questionid).FirstOrDefault();
                    return question;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return null;
        }

        //返回用户密保问题关系集
        public USER_QUESTION[] GetSecurityRelation(Decimal userid)
        {
            USER_QUESTION[] result;
            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    string sql = "select * from USER_QUESTION where USER_ID = " + userid ;
                    result = db.Database.SqlQuery<USER_QUESTION>(sql).ToArray();
                    return result;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return null;
        }

        //添加用户保护问题
        public void CreateSecurityQuestion(Decimal questionid, Decimal userid, String ans)
        {
            USER_QUESTION user_question = new USER_QUESTION 
            {
                ID = this.GetSeqNextVal("user_question"),
                USER_ID = userid,
                QUESTION_ID = questionid,
                ANSWER = ans
            };
            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    db.USER_QUESTION.Add(user_question);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Unique");
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
        }

        //添加新的密保问题
        public void CreateNewQuestion(HttpRequest Request)
        {
            string content = Request.Form["content"];
            string format = Request.Form["format"];
            string tip = Request.Form["tip"];

            QUESTION question = new QUESTION
            {
                QUESTION_ID = this.GetSeqNextVal("question"),
                CONTENT = content,
                QUESTION_FORMAT = format,
                FORMAT_TIP = tip
            };

            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    db.QUESTION.Add(question);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Unique");
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }

        }

        public DIALOG[] GetDialogs(Decimal userid)
        {
            DIALOG[] result;
            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    string sql = "select * from DIALOG where USER1 = "+ userid + " or USER2 =  "+ userid ;
                    result = db.Database.SqlQuery<DIALOG>(sql).ToArray();
                    return result;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return null;
            }

        public decimal CreateNewDialog(Decimal user1, Decimal user2)
        {
            DIALOG dialog = new DIALOG
            {
                DIALOG_ID = this.GetSeqNextVal("dialog"),
                USER1 = user1,
                USER2 = user2
            };
            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    db.DIALOG.Add(dialog);
                    db.SaveChanges();
                    return dialog.DIALOG_ID;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Unique");
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    return -1;
        }
            }
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
                    pwd = db.ACCOUNT.Where(p => p.EMAIL == Email).FirstOrDefault().PASSWORD;
                    pwd = MD5.EncryptMD5WithRule(pwd);
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
                        string sql = "(select * from PUBLISHMENT where PLACE like \'%" + keyword + "%\') ";
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
                    result.Sort(delegate(ItemEx a, ItemEx b) { return b.PUBLISHMENT_ID.CompareTo(a.PUBLISHMENT_ID); });
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
                    result.Sort(delegate(ItemEx a, ItemEx b) { return b.PUBLISHMENT_ID.CompareTo(a.PUBLISHMENT_ID); });
                    return result.ToArray();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return null;
        }

        //根据dialogid获得message
        public MESSAGE[] GetMessageByDialogId(decimal dialogId)
        {
            List<MESSAGE> result = new List<MESSAGE>();
            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    foreach (var q in db.DIALOG.Where(p => p.DIALOG_ID == dialogId).FirstOrDefault().DIALOG_MESSAGE)
                    {
                        MESSAGE message = new MESSAGE
                        {
                            MESSAGE_ID = q.MESSAGE_ID,
                            SENDER_ID = q.MESSAGE.SENDER_ID,
                            CONTENT = q.MESSAGE.CONTENT,
                            SENDTIME = q.MESSAGE.SENDTIME,
                            IS_READ = q.MESSAGE.IS_READ
                        };
                        result.Add(message);
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

        //创建message
        public void createMessage(Decimal dialogid, String content, Decimal sender)
        {

           

            MESSAGE message = new MESSAGE
            {
                MESSAGE_ID = this.GetSeqNextVal("message"),
                SENDER_ID = sender,
                CONTENT = content,
                SENDTIME = DateTime.Now,
                IS_READ = 0
            };

            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    MESSAGE tempmessage = db.MESSAGE.Add(message);
                    DIALOG_MESSAGE dialog = new DIALOG_MESSAGE
                    {
                        ID = this.GetSeqNextVal("DIALOG_MESSAGE"),
                        DIALOG_ID = dialogid,
                        MESSAGE_ID = tempmessage.MESSAGE_ID
                    };

                    db.DIALOG_MESSAGE.Add(dialog);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Unique");
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
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
                            || i.PUBLISH_DATE.ToString()==(SearchString)
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
            return result.ToArray();
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
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return null;
        }
        //根据用户id获得用户信息
        public PersonAllMessage GetUserMessage(decimal UserId)
        {
            PersonAllMessage result;
            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    result = db.Database.SqlQuery<PersonAllMessage>("select user_name,email,birth,sex,phone,marjor,address from account, user_userinfo, userinfo where account.user_id=" + UserId + " and account.user_id=user_userinfo.account and user_userinfo.userinfo=userinfo.userinfo_id").FirstOrDefault();
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

        public ItemEx[] GetLostItemByID(decimal user_id)
        {
            List<ItemEx> result = new List<ItemEx>(); 
            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    foreach (var i in db.PUBLISHMENT)
                    {
                        // 判断是否为丢失物品
                        if (!i.TYPE.Equals("lost") || !i.PUBLISHER_ID.Equals(user_id))
                        {
                            continue;
                        }

                        ItemEx itexEx = new ItemEx
                        {
                            PUBLISHMENT_ID = i.ID,
                            ITEM_ID = i.ITEM_ID,
                            ITEM_NAME = i.ITEM.ITEM_NAME,
                            PUBLISH_DATE = i.PUBLISH_DATE,
                            PLACE = i.PLACE
                        };

                        result.Add(itexEx);
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
        public ItemEx[] GetFoundItemByID(decimal user_id)
        {
            List<ItemEx> result = new List<ItemEx>(); 
            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    foreach (var i in db.PUBLISHMENT)
                    {
                        // 判断是否为丢失物品
                        if (!i.TYPE.Equals("found") || !i.PUBLISHER_ID.Equals(user_id))
                        {
                            continue;
                        }

                        ItemEx itexEx = new ItemEx
                        {
                            PUBLISHMENT_ID = i.ID,
                            ITEM_ID = i.ITEM_ID,
                            ITEM_NAME = i.ITEM.ITEM_NAME,
                            PUBLISH_DATE = i.PUBLISH_DATE,
                            PLACE = i.PLACE
                        };

                        result.Add(itexEx);
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
        public COMMENTS[] GetComments(decimal itemId)
        {
            List<COMMENTS> result = new List<COMMENTS>();
                using (LFMSContext db = new LFMSContext())
                {
                    try
                    {
                    var a = db.COMMENT_ITEM_USER.Where(p => p.ITEM_ID == itemId);
                    foreach (var q in a)
                        {
                            result.Add(q.COMMENTS);
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
        //通过item_id 获得的信息：  用于detail信息界面

        //通过item_id获得发现者(遗失者)的姓名  电话  
        public PersonAllMessage GetUserMessageByItemID(decimal itemId)
        {
            PersonAllMessage message;
            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    //先获得用户id 然后再获得用户信息
                    decimal user_id = db.Database.SqlQuery<decimal>("select publisher_id from publishment where item_id=" + itemId +" ").FirstOrDefault();
                    message = GetUserMessage(user_id);
                    return message;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    }
                }
                return null;
            }

        //通过item_id 获得item信息
        public ITEM GetItemByItemID(decimal itemId)
        {
            ITEM message;
            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    message = db.ITEM.Where(p => p.ITEM_ID == itemId).SingleOrDefault();
                    return message;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return null;
        }
        //通过item_id 获得publishment信息
        public PUBLISHMENT GetPublishmentByItemID(decimal itemId)
        {
            PUBLISHMENT message;
            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    message = db.PUBLISHMENT.Where(p=>p.ITEM_ID==itemId).SingleOrDefault();
                    return message;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return null;
        }
        //根据物品id获得物品评论信息
        public User_Comment[] GetUserCommentByItemID(decimal itemId)
        {
            User_Comment[] message;
            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    //sql语句有点长，老师要求放在配置文件中(鲁棒性)  评论按照发布时间排序
                    message = db.Database.SqlQuery<User_Comment>("select user_name,content,time from comments,comment_item_user,userinfo,user_userinfo where item_id=" + itemId + "and user_userinfo.account=user_id and user_userinfo.userinfo=userinfo_id and comments.comment_id=comment_item_user.comment_id order by time").ToArray();
                    return message;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return null;
        }

      

        // 根据User ID获取用户信息
        public USERINFO GetUserInfo(decimal userID)
        {
            USERINFO userInfo = new USERINFO();
            using(LFMSContext db = new LFMSContext())
            {
                try
                {
                    // 在联系集中找User ID对应的项
                    USER_USERINFO temp = db.USER_USERINFO.Where(p=> p.ACCOUNT == userID).FirstOrDefault();
                    userInfo = temp.USERINFO1;
                    return userInfo;
                }
                catch(Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
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

        //由密保问题ID获得密保问题
        public QUESTION GetQustion(int question_id)
        {
           
            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    QUESTION q = db.QUESTION.Where(p => p.QUESTION_ID == question_id).FirstOrDefault();
                    return q;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return null;
        
        }
        //delete item by id
        public bool DeleteItemByID(int id)
        {
             using (LFMSContext db = new LFMSContext())
                {
                try
                {
                    db.PUBLISHMENT.Remove(db.PUBLISHMENT.Where(p => p.ITEM_ID == id).SingleOrDefault());
                    db.ITEM.Remove(db.ITEM.Where(p => p.ITEM_ID == id).SingleOrDefault());
                    db.SaveChanges();
                     return true;
                }
                catch (Exception ex)
                {
                     System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return false;
        
        
        }
        //删除用户
        //success
        //删除用户的提问
        public bool DeleteQuestionByUserID(int id)
        {
            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    USER_QUESTION[] ques= db.USER_QUESTION.Where(p=>p.USER_ID==id).ToArray();
                    foreach (var i in ques)
                    {
                        db.QUESTION.Remove(db.QUESTION.Where(p => p.QUESTION_ID == i.QUESTION_ID).SingleOrDefault());
                        db.USER_QUESTION.Remove(i);
                    }
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return false;
        }
        //删除用户的信息
        
        //success
        public bool DeleteItemByUserID(int id)
        {
            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    PUBLISHMENT[] pub = db.PUBLISHMENT.Where(p => p.PUBLISHER_ID == id).ToArray();
                    foreach (var i in pub)
                    {
                        DeleteItemByID((int)i.ITEM_ID);
                    }
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return false;
        }
        //success
        public bool DeleteDialogByUserID(int id)
        {
            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    DIALOG[] dia = db.DIALOG.Where(p => p.USER1 == id || p.USER2 == id).ToArray();
                    foreach (var i in dia)
                    {
                        DIALOG_MESSAGE[] d_m = db.DIALOG_MESSAGE.Where(p => p.DIALOG_ID == i.DIALOG_ID).ToArray();

                        foreach (var j in d_m)
                        {
                            db.MESSAGE.Remove(db.MESSAGE.Where(p => p.MESSAGE_ID == j.MESSAGE_ID).SingleOrDefault());
                            db.DIALOG_MESSAGE.Remove(j);
                        }
                        db.DIALOG.Remove(i);
                    }
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return false;
        }
        //根据id删除用户
        public bool DeleteUserByID(int id)
        {
             using (LFMSContext db = new LFMSContext())
                {
                try
                {
                    DeleteQuestionByUserID(id);
                    DeleteItemByUserID(id);
                    DeleteDialogByUserID(id);

                    USER_USERINFO temp = db.USER_USERINFO.Where(p => p.ACCOUNT == id).SingleOrDefault();
                    db.USERINFO.Remove(db.USERINFO.Where(p => p.USERINFO_ID == temp.USERINFO).SingleOrDefault());
                    db.USER_USERINFO.Remove(temp);
                    
                    db.ACCOUNT.Remove(db.ACCOUNT.Where(p => p.USER_ID == id).SingleOrDefault());
                    
                    db.SaveChanges();
                     return true;
                }
                catch (Exception ex)
                {
                     System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return false;
        
        
        }


        public ACCOUNT GetAccountByUserID(int id)
        {
            
            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    ACCOUNT account = db.ACCOUNT.Where(p=>p.USER_ID==id).SingleOrDefault();
                    return account;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return null;
        
        }
        //更新
        //根据account的user_id更新account
        public void UpdateAccount(ACCOUNT nowAccout)
        {
            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    ACCOUNT old= db.ACCOUNT.Where(p => p.USER_ID == nowAccout.USER_ID).SingleOrDefault();
                    old.PASSWORD = nowAccout.PASSWORD;
                    old.EMAIL = nowAccout.EMAIL;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
        }
        //根据userinfo的userinfo_id更新
        public void UpdateUserInfo( USERINFO nowinfo)
        {
            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    USERINFO old = db.USERINFO.Where(p => p.USERINFO_ID == nowinfo.USERINFO_ID).SingleOrDefault();
                    old.PHONE = nowinfo.PHONE;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
        }
        //更新item
        public void UpdateItem(ITEM nowitem)
        {
            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    ITEM old = db.ITEM.Where(p => p.ITEM_ID == nowitem.ITEM_ID).SingleOrDefault();
                    old.ITEM_NAME = nowitem.ITEM_NAME;
                    old.IMAGE = nowitem.IMAGE;
                    old.ITEM_DESCRIPTION = nowitem.ITEM_DESCRIPTION;

                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
        }
        //更新PUBLISHMENT
        public void UpdatePublish(PUBLISHMENT nowpub)
        {
            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    PUBLISHMENT old = db.PUBLISHMENT.Where(p => p.ITEM_ID == nowpub.ITEM_ID).SingleOrDefault();
                    old.PLACE = nowpub.PLACE;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
        }


        //admin.后台管理编辑数据
        public bool ResetData(DataPackeg data)
        {
            bool result = true;

            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    // 获取项
                    
                    /*ACCOUNT account = db.ACCOUNT.Where(p => p.USER_ID == userID).FirstOrDefault();

                    account.PASSWORD = newPwdMD5;

                    db.SaveChanges();*/

                }
                catch (Exception ex)
                {
                    result = false ;
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }

            return result;
        }

        // 更新用户信息
        public void UpdateUserInfo(decimal userID, USERINFO userInfo)
        {
            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    USER_USERINFO connection = db.USER_USERINFO.Where(p => p.ACCOUNT == userID).FirstOrDefault();
                    USERINFO oldUserInfo = connection.USERINFO1;
                    oldUserInfo.USER_NAME = userInfo.USER_NAME;
                    oldUserInfo.PHONE = userInfo.PHONE;
                    oldUserInfo.ADDRESS = userInfo.ADDRESS;
                    oldUserInfo.MARJOR = userInfo.MARJOR;
                    oldUserInfo.SEX = userInfo.SEX;
                    oldUserInfo.BIRTH = userInfo.BIRTH;

                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
        }

        // 获取用户权限
        public decimal GetUserPrivilege(decimal userID)
        {
            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    ACCOUNT account = db.ACCOUNT.Where(p => p.USER_ID == userID).FirstOrDefault();
                    return account.PRIVILEGE;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return -1;
        }
    }

    public class DataPackeg
    {
        public static string selfClass ;
        public static object data;
        public DataPackeg(object Obj , string T)
        {
            selfClass = T ;
            data = Obj;
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