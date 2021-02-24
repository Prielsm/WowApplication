using BundleTransformer.Core.Builders;
using BundleTransformer.Core.Bundles;
using BundleTransformer.Core.Orderers;
using BundleTransformer.Core.Resolvers;
using System.Web;
using System.Web.Optimization;

namespace WowApplication
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/script").Include
                (
                 "~/Js/script.js"
                ));

            var nullBulider = new NullBuilder();
            var nullOrderer = new NullOrderer();

            BundleResolver.Current = new CustomBundleResolver();
            var commonStyleBundle = new CustomStyleBundle("~/Bundle/sass");


            commonStyleBundle.Include("~/Scss/styles.scss");
            commonStyleBundle.Include("~/Scss/loot.scss");
            commonStyleBundle.Include("~/Scss/donjons.scss");
            //... Ajouter d'autres scss
            commonStyleBundle.Orderer = nullOrderer;
            bundles.Add(commonStyleBundle);
        }
    }
}
