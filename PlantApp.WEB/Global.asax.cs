using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using PlantApp.BLL.Infrastructure;
using PlantApp.WEB.Util;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PlantApp.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //внедрение зависимостей
            NinjectModule workcenterModule = new WorkcenterModule();
            NinjectModule serviceModule = new ServiceModule("PlantAppConnectionSQLEXPRESS");
            var kernel = new StandardKernel(workcenterModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
