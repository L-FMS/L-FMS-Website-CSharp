using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace L_FMS
{
    public partial class Settings : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 加载用户信息
            this.Load_User_Info();
        }

        private void Load_User_Info()
        {
            // 从Session中获取User ID
            decimal userID = (decimal)Session["userID"];

            // 根据User ID获取用户信息
            USERINFO userInfo = DBModel.GetInstance().GetUserInfo(userID);

            // 根据所获得的结果加载页面信息
            this.name.Value = userInfo.USER_NAME;
            this.sex.SelectedIndex = userInfo.SEX.Equals("M") ? 1 : 2;
            this.birth.Value = String.Format("{0:yyyy-MM-dd}", userInfo.BIRTH);
            this.phone.Value = userInfo.PHONE;
            this.major.Value = userInfo.MARJOR;
            this.address.Value = userInfo.ADDRESS;
        }

        protected void Update_Info(object sender, EventArgs e)
        {
            USERINFO userInfo = new USERINFO
            {
                USER_NAME = Request.Form.GetValues(1)[0],
                PHONE = Request.Form.GetValues(4)[0],
                ADDRESS = Request.Form.GetValues(6)[0],
                MARJOR = Request.Form.GetValues(5)[0],
                SEX = Request.Form.GetValues(2)[0].Equals("0") ? "M" : "F",
                BIRTH = DateTime.ParseExact(Request.Form.GetValues(3)[0], "yyyy-MM-dd", null)
            };
            DBModel.GetInstance().UpdateUserInfo((decimal)Session["userID"], userInfo);

            Response.Redirect("~/");
        }
    }
}