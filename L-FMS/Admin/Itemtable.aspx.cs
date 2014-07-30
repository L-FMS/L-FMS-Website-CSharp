using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace L_FMS.Admin
{
    public partial class Itemtable1 : System.Web.UI.Page
    {

        protected PUBLISHMENT[] pubs { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            pubs = DBModel.GetInstance().GetPublishment(null);
        }

        protected void Item_Search(object sender, EventArgs e)
        {
            string keyword = Request.Form["itemkeyword"];
            pubs = DBModel.GetInstance().GetPublishment(keyword);
        }
    }
}