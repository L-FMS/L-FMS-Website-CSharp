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

            bundles.Add(new ScriptBundle("~/scripts/Admin").Include(
                "~/scripts/jquery-2.0.3.min.js",
                "~/Admin/assets//javascripts/jquery-ui.min.js",
                "~/Admin/assets/javascripts/modernizr.min.js",
                "~/Admin/assets/javascripts/application-985b892b.js"));

            bundles.Add(new ScriptBundle("~/scripts/Detail").Include(
                "~/scripts/detail.js"));

            bundles.Add(new ScriptBundle("~/scripts/Post").Include(
               "~/scripts/bootstrap-select.js",
               "~/scripts/bootstrap-filestyle.min.js",
               "~/scripts/jquery.tagsinput.js"));

            bundles.Add(new ScriptBundle("~/scripts/BootstrapSelect").Include(
               "~/scripts/bootstrap-select.js"));
        }
        public BundleConfig()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
    }
}
