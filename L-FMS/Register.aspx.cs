using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.Entity.Infrastructure;

namespace L_FMS
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Create_User(object sender, EventArgs e)
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

            using (LFMSContext db = new LFMSContext())
            {

                try
                {
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

                    db.ACCOUNT.Add(account);
                    db.USERINFO.Add(userinfo);
                    db.USER_USERINFO.Add(user_userinfo);
                    db.SaveChanges();



                    // 跳转回主页
                    Response.Redirect("~/");
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