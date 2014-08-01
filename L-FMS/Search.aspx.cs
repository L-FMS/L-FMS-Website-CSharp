using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Entity.Infrastructure;

namespace L_FMS
{
    public partial class Search : System.Web.UI.Page, IPostBackEventHandler
    {
        protected DataTable dt = new DataTable();
        protected ItemEx[] itemMessage;
        protected void Page_Load(object sender, EventArgs e)
        {
            string query = Request.Params["q"];
            if (query == null || query.Equals(""))
            {
                // query为空
                // 直接重定向到错误界面
                Session["errorMessage"] = "您所访问的页面不存在";
                Session["returnURL"] = "Default.aspx";
                Response.Redirect("~/Error.aspx");
            }

            dt.Columns.Add("name");
            dt.Columns.Add("date");
            dt.Columns.Add("place");

            //根据query 在publishment表中获取信息
            itemMessage = DBModel.GetInstance().GetItemBySearchString(query);
          //  if(itemMessage!=null)
            foreach (var i in itemMessage)
            {
                object[] dr = new object[3];
                dr[0] = i.ITEM_NAME;
                dr[1] = i.PUBLISH_DATE.ToString();
                dr[2] = i.PLACE;
                dt.Rows.Add(dr);
            }
            
            if (dt.Rows.Count != 0)
            {
                this.searchItem.DataSource = dt;
                this.searchItem.DataBind();
                this.searchItem.UseAccessibleHeader = true;
                this.searchItem.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
        {
            if (eventArgument.StartsWith("searchItemClick:"))
            {
                string temp = eventArgument.Substring(16);
                searchItem_click(int.Parse(temp));
            }
        }

        private void searchItem_click(int rowIndex)
        {
            Session["ItemId"] =itemMessage[rowIndex].ITEM_ID;
            Session["PublishmentId"] = itemMessage[rowIndex].PUBLISHMENT_ID;
            Response.Redirect("Detail.aspx");
        }
        protected void searchItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex < 0)
            {
                return;
            }
            e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackEventReference(this, "searchItemClick:" + e.Row.RowIndex.ToString());
        }

    }
}
