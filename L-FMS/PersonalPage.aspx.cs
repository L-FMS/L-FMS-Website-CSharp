using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace L_FMS
{

    public partial class PersonalPage : System.Web.UI.Page
    {
        protected PersonMessage message;
        protected string[] lost;
        protected string[] found;
        protected void Page_Load(object sender, EventArgs e)
        {
            int User_ID=0;
            message = DBModel.GetInstance().GetUserMessage(User_ID);
            // id对应的用户不存在
            if (message == null)
            {
                Session["errorMessage"] = "用户不存在";
                Response.Redirect("Login.aspx");
            }
            if (message.SEX == "M")
            { 
                message.SEX = "男"; 
            }
            else
            { 
                message.SEX = "女"; 
            }
            lost = DBModel.GetInstance().GetLostItemByID(User_ID);
            found = DBModel.GetInstance().GetFoundItemByID(User_ID);
        }
    }
}