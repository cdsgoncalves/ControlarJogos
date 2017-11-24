using System;
using System.Web.Optimization;

namespace Web
{
    public static class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            AddDefaultIgnorePatterns(bundles.IgnoreList);
            RegistrarBundlesCss(bundles);
            RegistrarBundlesJavascript(bundles);
            BundleTable.EnableOptimizations = true;
        }

        private static void RegistrarBundlesJavascript(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/js/site")
                // jQuery 3.1.1
                .Include("~/Content/plugins/jQuery/jquery-3.1.1.min.js")
                // Bootstrap 3.3.7
                .Include("~/Content/bootstrap/js/bootstrap.min.js")
                // SlimScroll
                .Include("~/Content/plugins/slimScroll/jquery.slimscroll.min.js")
                // FastClick
                .Include("~/Content/plugins/fastclick/fastclick.js")
                // AdminLTE App
                .Include("~/Content/dist/js/adminlte.min.js")
                // Máscaras
                .Include("~/Content/js/jquery.maskedinput-1.3.1.min.js")
                // Bootbox
                .Include("~/Scripts/bootbox.min.js"));

            bundles.Add(new ScriptBundle("~/Content/js/datatables")
                .Include("~/Content/plugins/datatables/jquery.dataTables.js")
                .Include("~/Content/plugins/datatables/dataTables.bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/Content/js/custom")
                 // Util são funções próprias do sistema
                 .Include("~/Content/js/Util.js"));
        }

        private static void RegistrarBundlesCss(BundleCollection bundles)
        {
            //CSS das Fontes Awesome e Opensans
            //Obs.: NÃO alterar o nome do bundle. O Font-Awesome usa, internamente em seus css, redirecionamento
            //relativo (../). Usar CssRewriteUrlTransformation neste caso não resolve para sites rodando como subsite.
            // Como o bundles ainda não possui suporte para resolver Urls internas nos css, temos que nomear o bundle
            //com a mesma estrutura de pastas, mudando apenas o final (nome do bundle em si, note que da pasta css para
            //trás é a mesma estrutura física de pastas do site).
            //Referência: http://stackoverflow.com/questions/11355935/mvc4-stylebundle-not-resolving-images
            //Vide comentário Hao Kung Jul 13 '12 at 22:56
            bundles.Add(new StyleBundle("~/Content/font-awesome/css/font-awesome")
                .Include("~/Content/font-awesome/css/font-awesome.min.css")
                .Include("~/Content/font-opensans/css/font-opensans.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap/css/bootstrap")
                .Include("~/Content/bootstrap/css/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/Content/css/datatables")
                .Include("~/Content/plugins/datatables/jquery.dataTables.css")
                .Include("~/Content/plugins/datatables/dataTables.bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/css/site")
                // Theme style
                .Include("~/Content/dist/css/AdminLTE.min.css")
                // AdminLTE Skins.Choose a skin from the css/ skins folder instead of downloading all of them to reduce the load.
                .Include("~/Content/dist/css/skins/skin-blue.min.css")
                .Include("~/Content/Site.css"));
        }

        public static void AddDefaultIgnorePatterns(IgnoreList ignoreList)
        {
            if (ignoreList == null)
                throw new ArgumentNullException(nameof(ignoreList));

            ignoreList.Ignore("*.intellisense.js");
            ignoreList.Ignore("*-vsdoc.js");
            ignoreList.Ignore("*.debug.js", OptimizationMode.WhenEnabled);
        }
    }
}