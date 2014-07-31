using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace L_FMS
{
    public partial class List : System.Web.UI.Page, IPostBackEventHandler
    {
        protected DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            dt.Columns.Add("rank");
            dt.Columns.Add("name");
            dt.Columns.Add("number");

            UserOrdered[] list = DBModel.GetInstance().GetUserOrdered();
            //  if(itemMessage!=null)
            int count = 0;
         foreach (var i in list)
            {
                object[] dr = new object[3];
                dr[0] = ++count;
                dr[1] = DBModel.GetInstance().GetUserName(i.publisher_id);
                dr[2] = i.sum;
                dt.Rows.Add(dr);

            }
            this.tableList.DataSource = dt;
            this.tableList.DataBind();
            this.tableList.UseAccessibleHeader = true;
            this.tableList.HeaderRow.TableSection = TableRowSection.TableHeader;


        }

        void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
        {
            if (eventArgument.StartsWith("tableListClick:"))
            {
                string temp = eventArgument.Substring(15);
                tableList_click(int.Parse(temp));
            }
        }

        private void tableList_click(int rowIndex)
        {
            string id = DBModel.GetInstance().GetUserOrdered()[rowIndex].publisher_id.ToString();
            Response.Redirect("PersonalPage.aspx?userID="+id);
        }
        protected void tableList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex < 0)
            {
                return;
            }
            e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackEventReference(this, "tableListClick:" + e.Row.RowIndex.ToString());
        }
    }

}