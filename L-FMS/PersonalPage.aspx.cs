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
        protected PersonAllMessage message;
        protected ItemEx[] lost;
        protected ItemEx[] found;
        protected void Page_Load(object sender, EventArgs e)
        {
            decimal User_ID = 0;
            // 如果URL参数中存在userID参数，以此优先
            if (Request.Params["userID"] != null)
            {
                User_ID = Decimal.Parse(Request.Params["userID"]);
            }
            else
            {
                // URL中无此参数
                // 去Session中寻找当前用户的User ID
                User_ID = Decimal.Parse(Session["userID"].ToString());

                if (User_ID == -1)
                {
                    // 用户未登录
                    // 重定向
                    Response.Redirect("~/Login.aspx?redirect=/PersonalPage.aspx");
                }
            }

            message = DBModel.GetInstance().GetUserMessage(User_ID);
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