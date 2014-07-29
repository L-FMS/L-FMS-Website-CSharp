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

            if(pwd.Equals(pwdValidate))
            {
                pwd = MD5.Encrypt(pwd);
            }

            string name = Request.Form["user-name"];
            string phone = Request.Form["phone"];
            string address = Request.Form["address"];
            string major = Request.Form["major"];
            string sex = Request.Form["sex"];
            string birth = Request.Form["birth"];

            //string g = "<script>alert(\"" + email + "\\n" + pwd + "\\n" + name + "\\n" + sex + "\\n" + phone + "\\n" + DateTime.ParseExact(birth, "yyyy-MM-dd", null) + "\\n" + major + "\\n" + address + "\")</script>";
            //Response.Write(g);

            using (LFMSContext db = new LFMSContext())
            {
                try
                {
                    ACCOUNT account = new ACCOUNT
                    {
                        EMAIL = email,
                        PASSWORD = pwd,
                        PRIVILEGE = 1,
                        VERIFIED = 1
                    };

                    USER_INFO userInfo = new USER_INFO
                    {
                        USER_NAME = name,
                        PHONE = phone,
                        ADDRESS = address,
                        MARJOR = major,
                        SEX = (sex.Equals("0") ? "M" : "F"),
                        BIRTH = DateTime.ParseExact(birth, "yyyy-MM-dd", null)
                    };

                    db.ACCOUNT.Add(account);
                    db.SaveChanges();

                    ACCOUNT newAccount = db.ACCOUNT.Where(p => p.EMAIL == account.EMAIL).FirstOrDefault();

                    account.USER_ID = newAccount.USER_ID;
                    userInfo.ACCOUNT = account;

                    userInfo.USER_ID = newAccount.USER_ID;

                    System.Diagnostics.Debug.WriteLine(userInfo.USER_ID);
                    System.Diagnostics.Debug.WriteLine(userInfo.USER_NAME);
                    System.Diagnostics.Debug.WriteLine(userInfo.ADDRESS);
                    System.Diagnostics.Debug.WriteLine(userInfo.MARJOR);
                    System.Diagnostics.Debug.WriteLine(userInfo.SEX);
                    System.Diagnostics.Debug.WriteLine(userInfo.BIRTH);
                    System.Diagnostics.Debug.WriteLine(userInfo.PHONE);

                    db.USER_INFO.Add(userInfo);
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