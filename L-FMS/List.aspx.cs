using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace L_FMS
{
    public partial class List : System.Web.UI.Page
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
                dr[2] = i.tot;
                dt.Rows.Add(dr);

            }
            this.searchItem.DataSource = dt;
            this.searchItem.DataBind();
            this.searchItem.UseAccessibleHeader = true;
            this.searchItem.HeaderRow.TableSection = TableRowSection.TableHeader;


        }
    }

}