using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace L_FMS.Admin
{
    public partial class Edit : System.Web.UI.Page
    {
        protected ITEM editItem;
        protected PUBLISHMENT editPublishment;
        protected string editType;
        protected ACCOUNT editAccount;
        protected USERINFO editUserInfo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["editItemID"] != null)
            {
                string a=Request["editItemID"];
                editType = "Item";
                editItem=DBModel.GetInstance().GetItemByItemID(int.Parse(a));
                editPublishment = DBModel.GetInstance().GetPublishmentByItemID(int.Parse(a));
            }
            else if(Request["editUserID"]!=null)
            {
                string a = Request["editUserID"];
                editType = "User";
                editAccount = DBModel.GetInstance().GetAccountByUserID(int.Parse(a));
                editUserInfo = DBModel.GetInstance().GetUserInfo(int.Parse(a));
            }
            else
            {
                Session["errorMessage"]="找不到item";
                Response.Redirect("../Error.aspx");
            }
        }
        protected void update_item(object sender, EventArgs e)
        {
            editItem = DBModel.GetInstance().GetItemByItemID(int.Parse(Request.Form["item_id"]));
            editPublishment = DBModel.GetInstance().GetPublishmentByItemID(int.Parse(Request.Form["item_id"]));
            editItem.ITEM_ID = int.Parse(Request.Form["item_id"]);
            editItem.ITEM_NAME = Request.Form["item_name"];
            editItem.ITEM_DESCRIPTION = Request.Form["item_des"];
            editPublishment.ITEM_ID = int.Parse(Request.Form["item_id"]);
            editPublishment.PLACE = Request.Form["item_place"];
            DBModel.GetInstance().UpdateItem(editItem);
            DBModel.GetInstance().UpdatePublish(editPublishment);
            Response.Redirect("Itemtable.aspx");
        }
        protected void update_user(object sender, EventArgs e)
        {
            editAccount = DBModel.GetInstance().GetAccountByUserID(int.Parse(Request.Form["user_id"]));
            editUserInfo = DBModel.GetInstance().GetUserInfo(int.Parse(Request.Form["user_id"]));
            editAccount.PASSWORD = MD5.Encrypt(Request.Form["acc_password"]);
            editAccount.EMAIL = Request.Form["acc_email"];
            editUserInfo.PHONE = Request.Form["user_phone"];

            DBModel.GetInstance().UpdateAccount(editAccount);
            DBModel.GetInstance().UpdateUserInfo(editUserInfo);
            Response.Redirect("Usertable.aspx");
        }

    }
}