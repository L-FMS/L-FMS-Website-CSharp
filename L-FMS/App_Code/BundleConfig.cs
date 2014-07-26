using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace DB
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/scripts/Base").Include(
                "~/scripts/jquery-2.0.3.min.js",
                "~/bootstrap/js/bootstrap.min.js"));
        }
        public BundleConfig()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
    }
}
