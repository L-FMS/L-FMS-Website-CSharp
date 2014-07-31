using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace L_FMS
{
    public partial class FindPassword : System.Web.UI.Page
    {

        
        protected Decimal userid;
        

        protected USER_QUESTION[] relations { get; set; }
       

        protected void Page_Load(object sender, EventArgs e)
        {
        }

       

        protected void Submit_Email(object sender, EventArgs e)
        {
            string email = Request.Form["email"];
            userid = DBModel.GetInstance().GetUserID(email);
            if (userid == -1)
            {
                Session["errorMessage"] = "用户名不存在";
                Session["returnURL"] = "FindPasswordLogIn.aspx";
                Response.Redirect("Error.aspx");
            }  
            else
            {
                relations = DBModel.GetInstance().GetSecurityRelation(userid);
                //questions = DBModel.GetInstance().GetSecurityQuesion(userid);
                if (relations.Length == 0)
                {
                    Session["errorMessage"] = "该用户未创立密码保护问题";
                    Session["returnURL"] = "FindPasswordLogin.aspx";
                    Response.Redirect("Error.aspx");
                } else
                {
                    Session["findPasswordUserId"] = userid;
                    //Session["returnURL"] = ;
                    Response.Redirect("FindPasswordVerified.aspx");
                }
            }
        }

        
    }
}