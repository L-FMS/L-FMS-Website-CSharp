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

        }
    }
}