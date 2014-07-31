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

        protected QUESTION[] questions { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            questions = new QUESTION[3];
            for (int i = 0; i < 3; ++i)
                questions[i] = DBModel.GetInstance().GetQustion(i + 1);
        }

        protected void Create_Question(object sender, EventArgs e)
        {
            

            Response.Redirect("~/");
        }
    }
}