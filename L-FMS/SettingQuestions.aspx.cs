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
        protected Boolean alreadyset { get; set; }
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

            Decimal userid = (Decimal)Session["userID"];
            alreadyset = DBModel.GetInstance().SecurityQuestion(userid);
            //alreadyset = false;
            if (!alreadyset)
            {
                questions = new QUESTION[3];
                for (int i = 0; i < 3; ++i)
                    questions[i] = DBModel.GetInstance().GetQustion(i + 1);
            }
            
        }

        protected void Create_Question(object sender, EventArgs e)
        {
            Decimal userid = (Decimal)Session["userID"];
            for (int i = 0; i < 3; ++i)
            {
                string ans = Request.Form["answer" + (i + 1)];
                DBModel.GetInstance().CreateSecurityQuestion(questions[i].QUESTION_ID, userid, ans);
            }      
                Response.Redirect("~/");
        }
    }
}