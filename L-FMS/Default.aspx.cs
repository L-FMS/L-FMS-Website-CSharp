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
    public partial class WebForm1 : System.Web.UI.Page, IPostBackEventHandler
    {
        protected DataTable dt = new DataTable();
        protected DataTable dt2 = new DataTable();
        ItemEx[] info;
        ItemEx[] info2;
        protected int lost_amount;
        protected int found_amount;
        protected void Page_Load(object sender, EventArgs e)
        {
            info = DBModel.GetInstance().GetLostItem();
            dt.Columns.Add("name");
            dt.Columns.Add("date");
            dt.Columns.Add("place");
            foreach (ItemEx p in info)
            {
                object[] dr = new object[3];
                dr[0] = p.ITEM_NAME;
                dr[1] = p.PUBLISH_DATE.ToString();
                dr[2] = p.PLACE;
                dt.Rows.Add(dr);
            }
            this.lost.DataSource = dt;
            this.lost.DataBind();
            this.lost.UseAccessibleHeader = true;
            this.lost.HeaderRow.TableSection = TableRowSection.TableHeader;
            lost_amount = this.lost.PageCount;

            info2 = DBModel.GetInstance().GetFoundItem();
            dt2.Columns.Add("name");
            dt2.Columns.Add("date");
            dt2.Columns.Add("place");
            foreach (ItemEx p in info2)
            {
                object[] dr = new object[3];
                dr[0] = p.ITEM_NAME;
                dr[1] = p.PUBLISH_DATE.ToString();
                dr[2] = p.PLACE;
                dt2.Rows.Add(dr);
            }
            this.found.DataSource = dt2;
            this.found.DataBind();
            this.found.UseAccessibleHeader = true;
            this.found.HeaderRow.TableSection = TableRowSection.TableHeader;
            found_amount = this.found.PageCount;
            
        }

        //lost click;
        void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
        {
            if (eventArgument.StartsWith("lostClick:"))
            {
                string temp = eventArgument.Substring(10);
                lost_click( int.Parse(temp) );
            }
            else if (eventArgument.StartsWith("foundClick:"))
            {
                string temp = eventArgument.Substring(11);
                found_click(int.Parse(temp));
            }
        }

        private void lost_click(int rowIndex)
        {
            Session["ItemId"] = info[rowIndex].ITEM_ID;
            Session["PublishmentId"] = info[rowIndex].PUBLISHMENT_ID;
            Response.Redirect("Detail.aspx");
        }
        protected void lost_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowIndex < 0)
            {
                return;
            }
            e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackEventReference(this, "lostClick:" + e.Row.RowIndex.ToString());
        }

        private void found_click(int rowIndex)
        {
            Session["ItemId"] = info2[rowIndex].ITEM_ID;
            Session["PublishmentId"] = info2[rowIndex].PUBLISHMENT_ID;
            Response.Redirect("Detail.aspx");
        }
        protected void found_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex < 0)
            {
                return;
            }
            e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackEventReference(this, "foundClick:" + e.Row.RowIndex.ToString());
        }

     
        //paging
        protected void found_pre_click(object sender, EventArgs e)
        {
            if (this.found.PageIndex > 0)
            {
                this.found.PageIndex--;
             
            }
            this.found.DataBind();
        }
        protected void found_next_click(object sender, EventArgs e)
        {
            if (this.found.PageIndex < this.found.PageCount-1)
            {
                this.found.PageIndex++;
                
            }
            this.found.DataBind();
        }

        protected void lost_pre_click(object sender, EventArgs e)
        {
            if (this.lost.PageIndex > 0)
            {
                this.lost.PageIndex--;
                
            }
            this.lost.DataBind();
        }
        protected void lost_next_click(object sender, EventArgs e)
        {
            if (this.lost.PageIndex < this.found.PageCount - 1)
            {
                this.lost.PageIndex++;

            }
            this.lost.DataBind();
        }

    }


}