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

            dt.Columns.Add("name");
            dt.Columns.Add("number");

         
            //  if(itemMessage!=null)
 /*           foreach (var i in itemMessage)
            {
                object[] dr = new object[2];
                dr[0] = i.ITEM_NAME;
                dr[1] = i.PUBLISH_DATE.ToString();
                dt.Rows.Add(dr);

            }
            this.searchItem.DataSource = dt;
            this.searchItem.DataBind();
            this.searchItem.UseAccessibleHeader = true;
            this.searchItem.HeaderRow.TableSection = TableRowSection.TableHeader;
  * */

        }
    }

}