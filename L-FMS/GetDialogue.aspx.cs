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

        protected DIALOG[] origindialogs { get; set; }
        protected Dialog_Name[] dialogs { get; set; }

        protected Decimal userid { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            // 判断用户是否登录
            if (!Utils.checkLogin(Session))
            {
                // 用户未登录
                // 不允许访问该页面
                // 跳转到登录界面
                Response.Redirect("~/Login.aspx?redirect=/GetDialogue.aspx");
            }

            userid = (Decimal)Session["userID"];
            origindialogs = DBModel.GetInstance().GetDialogs(userid);
            dialogs = new Dialog_Name[origindialogs.Length];
            for (int i = 0; i < origindialogs.Length; ++i)
            {
                dialogs[i] = new Dialog_Name();
                dialogs[i].DIALOG_ID = origindialogs[i].DIALOG_ID;
                if (origindialogs[i].USER1 == userid)
                    dialogs[i].CONTACT_NAME = DBModel.GetInstance().GetUserName(origindialogs[i].USER2);
                else
                    dialogs[i].CONTACT_NAME = DBModel.GetInstance().GetUserName(origindialogs[i].USER1);
            }

        }

        protected Decimal getDialogIDByUser2(Decimal user2)
        {
            for (int i = 0; i < origindialogs.Length; ++i)
                if ((origindialogs[i].USER1 == user2) || (origindialogs[i].USER2 == user2))
                    return origindialogs[i].DIALOG_ID;
            return -1;
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
                    Session["returnURL"] = "~/GetDialogue.aspx";
                    Response.Redirect("Error.aspx");
                }
                else if (user2 == userid)
                {
                    Session["errorMessage"] = "抱歉，您不能和自己通信";
                    Session["returnURL"] = "~/GetDialogue.aspx";
                    Response.Redirect("Error.aspx");
                }
                else{
                    Decimal id = getDialogIDByUser2(user2);
                    if ( id != (Decimal)(-1))
                    {
                        dialogid = id;
                        Session["currentDialog"] = dialogid;
                        Response.Redirect("Dialog.aspx");
                    }
                    else
                    {
                        dialogid = DBModel.GetInstance().CreateNewDialog(userid, user2);
                        Session["currentDialog"] = dialogid;
                        Response.Redirect("Dialog.aspx");
                    }
                } 
            }
            else
            {
                Session["currentDialog"] = dialogid;
                Response.Redirect("Dialog.aspx");
            }
        }
    }
}