using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace L_FMS
{
    public partial class Dialogue : System.Web.UI.Page
    {

        protected DIALOG[] dialogs { get; set; }

        protected Decimal userid { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            // 判断用户是否登录
            if (!Utils.checkLogin(Session))
            {
                // 用户未登录
                // 不允许访问该页面
                // 跳转到登录界面
                Response.Redirect("~/Login.aspx?redirect=/SettingQuestions.aspx");
            }

            userid = (Decimal)Session["userID"];
            dialogs = DBModel.GetInstance().GetDialogs(userid);

        }

        protected void SelectDialog(object sender, EventArgs e)
        {
           
            Decimal dialogid = Decimal.Parse(Request.Form["dialog"]);
            if (dialogid == -1)
            {
                string email = Request.Form["newdialog"];
                Decimal user2 = DBModel.GetInstance().GetUserID(email);
                if (user2 == -1)
                {
                    Session["errorMessage"] = "用户不存在";
                    Session["returnURL"] = "FindPasswordVerified.aspx";
                    Response.Redirect("Error.aspx");
                }
                else
                {
                    dialogid = DBModel.GetInstance().CreateNewDialog(userid, user2);
                    Session["currentDialog"] = dialogid;
                    Response.Redirect("Dialog.aspx");
                }
                    
            }
        }
    }
}