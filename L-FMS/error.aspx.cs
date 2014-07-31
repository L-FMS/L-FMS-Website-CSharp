using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace L_FMS
{
    public partial class error : System.Web.UI.Page
    {
        protected string errorMessage;

        protected void Page_Load(object sender, EventArgs e)
        {
            // 判断是否存在errorMessage
            if (!IsPostBack)
            {
                try
                {
            errorMessage = Session["errorMessage"].ToString();
                    Session.Remove("errorMessage");
        }
                catch (NullReferenceException nullEx)
                {
                    // 输出错误信息
                    System.Diagnostics.Debug.WriteLine(nullEx.Message);

                    // Session中errorMessage为空
                    // 直接跳转回主页
                    Response.Redirect("~/");
                }
            }
        }

        protected void goBack(object sender, EventArgs e)
        {
            string returnURL = Session["returnURL"].ToString();
            Session.Remove("returnURL");
            Response.Redirect(returnURL);
        }
    }
}