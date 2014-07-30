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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected DataTable dt = new DataTable();
        protected DataTable dt2 = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            ItemEx[] info=DBModel.GetInstance().GetLostItem();
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

            info = DBModel.GetInstance().GetFoundItem();
            dt2.Columns.Add("name");
            dt2.Columns.Add("date");
            dt2.Columns.Add("place");
            foreach (ItemEx p in info)
            {
                object[] dr = new object[3];
                dr[0] = p.ITEM_NAME;
                dr[1] = p.PUBLISH_DATE.ToString();
                dr[2] = p.PLACE;
                dt2.Rows.Add(dr);
            }
            this.found.DataSource = dt2;
            this.found.DataBind();
            
        }
    }
}