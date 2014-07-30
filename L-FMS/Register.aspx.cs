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
            decimal t = DBModel.GetInstance().GetSeqNextVal("user");
        }

        protected void Create_User(object sender, EventArgs e)
        {
            
            //string email = Request.Form["email"];
            //string pwd = Request.Form["pwd"];
            //string pwdValidate = Request.Form["pwd-validate"];

            //if(pwd.Equals(pwdValidate))
            //{
            //    pwd = MD5.Encrypt(pwd);
            //}

            //string name = Request.Form["user-name"];
            //string phone = Request.Form["phone"];
            //string address = Request.Form["address"];
            //string major = Request.Form["major"];
            //string sex = Request.Form["sex"];
            //string birth = Request.Form["birth"];

            //using (LFMSContext db = new LFMSContext())
            //{
                
            //    try
            //    {
            //        ACCOUNT account = new ACCOUNT
            //        {
            //            USER_ID = -1,
            //            EMAIL = email,
            //            PASSWORD = pwd,
            //            PRIVILEGE = 1,
            //            VERIFIED = 1
            //        };

            //        USER_INFO userInfo = new USER_INFO
            //        {
            //            EMAIL = email,
            //            USER_NAME = name,
            //            PHONE = phone,
            //            ADDRESS = address,
            //            MARJOR = major,
            //            SEX = (sex.Equals("0") ? "M" : "F"),
            //            BIRTH = DateTime.ParseExact(birth, "yyyy-MM-dd", null)
            //        };

            //        db.ACCOUNT.Add(account);

            //        // 输出调试
            //        System.Diagnostics.Debug.WriteLine(userInfo.EMAIL);
            //        System.Diagnostics.Debug.WriteLine(userInfo.USER_NAME);

            //        db.USER_INFO.Add(userInfo);
            //        db.SaveChanges();

                    

            //        // 跳转回主页
            //        Response.Redirect("~/");
            //    }
            //    catch (Exception ex)
            //    {
            //        System.Diagnostics.Debug.WriteLine("Unique");
            //        System.Diagnostics.Debug.WriteLine(ex.Message);
            //    }
            //}
        }
    }
}