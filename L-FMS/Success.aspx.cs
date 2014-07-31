using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace L_FMS
{
    public partial class Success : System.Web.UI.Page
    {
        protected string successMessage { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            // 判断是否存在successMessage
            try
            {
                successMessage = Session["successMessage"].ToString();
            }
            catch (NullReferenceException nullEx)
            {
                // 输出错误信息
                System.Diagnostics.Debug.WriteLine(nullEx.Message);

                // Session中successMessage为空
                // 直接跳转回主页
                Response.Redirect("~/");
            }
        }
        protected void goBack(object sender, EventArgs e)
        {
            string returnURL = Session["returnURL"].ToString();
            Session.Remove("returnURL");
            Session.Remove("successMessage");
            Response.Redirect(returnURL);
        }
    }
}