using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using L_FMS;

public partial class _Default : System.Web.UI.Page
{
    protected string Test
    {
        get;
        private set;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        LFMSContext db = new LFMSContext();
        ACCOUNT account = new ACCOUNT {
            EMAIL = "webmaster@h1994st.com",
            PASSWORD = "dddddddddddddddddddddddddddddddd",
            PRIVILEGE = 1,
            VERIFIED = 1
        };
        db.ACCOUNT.Add(account);
        db.SaveChanges();
    }
}