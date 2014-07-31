using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace L_FMS
{
    public partial class SettingQuestions : System.Web.UI.Page
    {

        protected QUESTION[] questions;
        protected void Page_Load(object sender, EventArgs e)
        {
           // questions = DBModel.GetInstance()
        }
    }
}