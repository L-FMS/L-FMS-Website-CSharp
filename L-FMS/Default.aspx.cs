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
        protected void Page_Load(object sender, EventArgs e)
        {
            DBModel.GetInstance().GetLostItem();
            dt.Columns.Add("name");
            dt.Columns.Add("date");
            dt.Columns.Add("place");
            object[] dr = new object[3];
            dr[0] = "qqq";
            dr[1] = "111";
            dr[2] = "333";
            dt.Rows.Add(dr);
            this.lost.DataSource = dt;
            this.lost.DataBind();


            
        }
    }
}