using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.WebPages;

namespace AtlUmbracoBundleGenerator.Extensions
{
    public static class AtlUmbracoBundle
    {
        /// <summary>
        /// Renders the styles.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="virtualPath">The virtual path.</param>
        /// <param name="additionalPaths">The additional paths.</param>
        /// <returns></returns>
        public static IHtmlString RenderStyles(this HtmlHelper helper, string virtualPath, params string[] additionalPaths)
        {
            if (BundleTable.Bundles.GetBundleFor(virtualPath) == null)
            {
                var bundles = new StyleBundle(virtualPath);
                foreach (var additionalPath in additionalPaths)
                {
                    var path = HostingEnvironment.MapPath(additionalPath);
                    if (path == null)
                        throw new Exception($"File not found at path: {additionalPath}");

                    var attr = File.GetAttributes(path);
                    if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                    {
                        bundles.IncludeDirectory(additionalPath, "*.css", true);
                    }
                    else
                    {
                        bundles.Include(additionalPath);
                    }
                }
                BundleTable.Bundles.Add(bundles);
            }
            return MvcHtmlString.Create($"<link href=\"{ HttpUtility.HtmlAttributeEncode(BundleTable.Bundles.ResolveBundleUrl(virtualPath))}\" rel=\"stylesheet\" />");
        }

        /// <summary>
        /// Renders the scripts.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="virtualPath">The virtual path.</param>
        /// <param name="additionalPaths">The additional paths.</param>
        /// <returns></returns>
        public static IHtmlString RenderScripts(this HtmlHelper helper, string virtualPath, params string[] additionalPaths)
        {
            if (BundleTable.Bundles.GetBundleFor(virtualPath) == null)
            {
                var bundles = new ScriptBundle(virtualPath);
                foreach (var additionalPath in additionalPaths)
                {
                    var path = HostingEnvironment.MapPath(additionalPath);
                    if (path == null)
                        throw new Exception($"File not found at path: {additionalPath}");

                    var attr = File.GetAttributes(path);
                    if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                    {
                        bundles.IncludeDirectory(additionalPath, "*.js", true);
                    }
                    else
                    {
                        bundles.Include(additionalPath);
                    }
                }
                BundleTable.Bundles.Add(bundles);
            }
            return MvcHtmlString.Create($"<script src=\"{HttpUtility.HtmlAttributeEncode(BundleTable.Bundles.ResolveBundleUrl(virtualPath))}\"></script>");
        }
    }
}
