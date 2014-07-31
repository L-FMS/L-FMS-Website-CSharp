using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace L_FMS
{
    public class Utils
    {
        public static bool checkLogin(HttpSessionState Session)
        {
            if (Session["isLogin"].Equals("true") &&
                !Session["userID"].Equals("-1") &&
                !Session["userName"].Equals("null"))
            {
                return true;
            }
            return false;
        }

        public static bool checkAdmin(decimal userID)
        {
            return DBModel.GetInstance().GetUserPrivilege(userID) == 0;
        }
    }
}