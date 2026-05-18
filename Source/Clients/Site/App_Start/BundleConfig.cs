using System.Web;
using System.Web.Optimization;


namespace Site
{
    public class BundleConfig
    {
        #region Methods
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleConfig.SetupJQuery(bundles);
            BundleConfig.SetupKnockout(bundles);
            BundleConfig.SetupBootstrap(bundles);
            BundleConfig.SetupSite(bundles);
        }
        #endregion

        #region Assistants
        private static void SetupJQuery(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts/jquery")
                .Include("~/Scripts/jquery-{version}.js"));
        }
        private static void SetupKnockout(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts/knockout")
                .Include("~/Scripts/knockout-{version}.js"));
        }
        private static void SetupBootstrap(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts/bootstrap")
                .Include("~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/bundles/styles/bootstrap")
                .Include("~/Content/bootstrap/bootstrap.css"));
        }
        private static void SetupSite(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts/api")
                .Include("~/Application/Api.js"));

            bundles.Add(new StyleBundle("~/bundles/styles/site")
                .Include("~/Content/Site.css"));
        }
        #endregion
    }
}
