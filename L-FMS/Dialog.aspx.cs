using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace L_FMS
{
    public partial class Dialog : System.Web.UI.Page
    {
        protected DataTable dt = new DataTable();
        protected Decimal dialogid { get; set; }
        protected int dialog_amount;
        protected MESSAGE[] messages { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            dialogid = (Decimal)Session["currentDialog"];
            //dialogid = 1;
            
            //找到对应messages，函数待添加
            messages = DBModel.GetInstance().GetMessageByDialogId(dialogid);

            dt.Columns.Add("id");
            dt.Columns.Add("date");
            dt.Columns.Add("sender");
            dt.Columns.Add("content");
            foreach (var p in messages)
            {
                object[] dr = new object[4];
                dr[0] = p.MESSAGE_ID;
                dr[1] = p.SENDTIME.ToString();
                dr[2] = DBModel.GetInstance().GetUserName(p.SENDER_ID);
                dr[3] = p.CONTENT;
                dt.Rows.Add(dr);
            }
            this.dialog.DataSource = dt;
            this.dialog.DataBind();
 //           this.dialog.UseAccessibleHeader = true;
 //           this.dialog.HeaderRow.TableSection = TableRowSection.TableHeader;
            dialog_amount = this.dialog.PageCount;
        }

        protected void found_pre_click(object sender, EventArgs e)
        {
            if (this.dialog.PageIndex > 0)
            {
                this.dialog.PageIndex--;

            }
            this.dialog.DataBind();
        }
        protected void found_next_click(object sender, EventArgs e)
        {
            if (this.dialog.PageIndex < this.dialog.PageCount - 1)
            {
                this.dialog.PageIndex++;

            }
            this.dialog.DataBind();
        }

        protected void Comment_Submit(object sender, EventArgs e)
        {
            string content = Request.Form["comment"];
            Decimal userid = (Decimal)Session["userID"];
            //Decimal userid = 43;
            //添加内容，函数待添加
            DBModel.GetInstance().createMessage(dialogid, content, userid);
        }

    }
}