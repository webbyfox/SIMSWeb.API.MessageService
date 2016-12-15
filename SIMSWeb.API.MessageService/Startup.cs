using Owin;
using SIMSWeb.API.MessageService.App_Start;
using System.Web.Http;
using WebApiContrib.IoC.Ninject;

namespace SIMSWeb.API.MessageService
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var configuration = new HttpConfiguration();
            configuration.DependencyResolver = new NinjectResolver(NinjectConfig.CreateKernel());
            WebApiConfig.Register(configuration);
            appBuilder.UseWebApi(configuration);
        }
    }
}