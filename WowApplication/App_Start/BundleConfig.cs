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
            var commonStyleBundle = new CustomStyleBundle("~/Bundle/cssBase");
            commonStyleBundle.Include("~/Scss/styles.scss");
            //... Ajouter d'autres scss
            commonStyleBundle.Orderer = nullOrderer;
            bundles.Add(commonStyleBundle);

            var donjonsStyleBundle = new CustomStyleBundle("~/Bundle/cssDonjons");
            donjonsStyleBundle.Include("~/Scss/donjons.scss");
            donjonsStyleBundle.Orderer = nullOrderer;
            bundles.Add(donjonsStyleBundle);

            var lootStyleBundle = new CustomStyleBundle("~/Bundle/cssLoot");
            lootStyleBundle.Include("~/Scss/loot.scss");
            lootStyleBundle.Orderer = nullOrderer;
            bundles.Add(lootStyleBundle);

            var loginStyleBundle = new CustomStyleBundle("~/Bundle/cssLogin");
            loginStyleBundle.Include("~/Scss/login.scss");
            loginStyleBundle.Orderer = nullOrderer;
            bundles.Add(loginStyleBundle);
        }
    }
}
