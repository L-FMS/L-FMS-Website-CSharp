using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace L_FMS
{
    public partial class FindPasssordVerified : System.Web.UI.Page
    {

        protected Decimal userid;
        protected QUESTION[] questions { get; set; }

        protected USER_QUESTION[] relations { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            userid = (Decimal)Session["findPasswordUserId"];
            relations = DBModel.GetInstance().GetSecurityRelation(userid);
            questions = new QUESTION[relations.Length];
            for (int i = 0; i < relations.Length; ++i)
                questions[i] = DBModel.GetInstance().GetSecurityQuesionByID(relations[i].QUESTION_ID);
        }

        protected void Submit_Answer(object sender, EventArgs e)
        {

            for (int i = 0; i < questions.Length; ++i)
            {
                string ans = Request.Form["ans" + i];
                string correctans = relations[i].ANSWER;
                if (!ans.Equals(correctans))
                {
                    Session["errorMessage"] = "问题回答错误";
                    Session["returnURL"] = "FindPasswordVerified.aspx";
                    Response.Redirect("Error.aspx");
                    break;
                }
            }

            Response.Redirect("FindPasswordNewPassword.aspx");

        }
    }
}