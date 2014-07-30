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
            string name=Request.Form["name"];
            string pwd = Request.Form["pwd"];
            string pass="";
            int count = 0;
            using (LFMSContext db = new LFMSContext())
            {
                var accounts= from p in db.ACCOUNT where p.EMAIL==name select p;
                
                foreach( var p in accounts)
                {
                    count++;
                    pass = MD5.EncryptMD5WithRule(p.PASSWORD);
                }
            }
            if( count==0)
            {
                //name is invalid
                this.aaa.Text = "name is invalid";
            }
            else
            {
                string pwd_md5 = MD5.EncryptMD5WithRule(MD5.Encrypt(pwd));
                if(pwd_md5==pass)
                {
                    //login successfully
                    this.aaa.Text = "login successfuly";
                    Session["name"] = name;
                    Response.Redirect("Default.aspx");
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