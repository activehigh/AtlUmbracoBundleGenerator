
using System.Linq;
using System.Web.Configuration;
using System.Web.Hosting;
using System.Web.Optimization;
using Umbraco.Core;

namespace AtlUmbracoBundleGenerator.Handlers
{
    public class ApplicationEventHandler : IApplicationEventHandler
    {
        public void OnApplicationInitialized(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            //override appsettings
            AddRouteToReseredRoutes();

            //register bundles
            RegisterBundles(BundleTable.Bundles);
        }

        public void OnApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            
        }

        public void OnApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            
        }

        #region Inner Methods

        /// <summary>
        /// Adds the route (~/bundles) to resered routes.
        /// </summary>
        private void AddRouteToReseredRoutes()
        {
            var appSettings = WebConfigurationManager.AppSettings["umbracoReservedPaths"] ?? "";

            if (appSettings.Split(',').Any(x => string.Equals("~/bundles", x.Trim())))
            {
                return;
            }

            appSettings += $"{(string.IsNullOrEmpty(appSettings) ? "" : ",")}~/bundles/";
            WebConfigurationManager.AppSettings["umbracoReservedPaths"] = appSettings;
        }

        /// <summary>
        /// Registers the bundles.
        /// </summary>
        /// <param name="bundles">The bundles.</param>
        private void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = true;
        }
        #endregion
    }
}
