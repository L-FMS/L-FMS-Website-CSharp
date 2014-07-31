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
            this.sex.Value = userInfo.SEX.Equals("M") ? "男" : "女";
            //this.birth.Value = userInfo.BIRTH.ToString();
            this.phone.Value = userInfo.PHONE;
            this.major.Value = userInfo.MARJOR;
            this.address.Value = userInfo.ADDRESS;
        }
    }
}