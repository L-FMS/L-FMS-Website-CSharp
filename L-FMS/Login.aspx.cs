using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace L_FMS
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void buttonSubmit(object sender, EventArgs e)
        {
            string email = Request.Form["email"];
            string pwd = Request.Form["pwd"];
            string pass = DBModel.GetInstance().GetUserPassword(email);

            if (pass.Equals(""))
            {
                //name is invalid
                this.aaa.Text = "name is invalid";
            }
            else
            {
                string pwd_md5 = MD5.Encrypt(pwd);
                if (pwd_md5.Equals(pass))
                {
                    //login successfully
                    this.aaa.Text = "login successfuly";
                    Session["userID"] = DBModel.GetInstance().GetUserID(email);
                    Session["isLogin"] = "true";
                    Session["userName"] = DBModel.GetInstance().GetUserName(email);
                    Response.Redirect("~/");
                }
                else
                {
                    //password is wrong
                    this.aaa.Text = "password is wrong";
                }
            }
        }
    }
}