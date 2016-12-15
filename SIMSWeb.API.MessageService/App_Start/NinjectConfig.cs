using Ninject;
using SIMSWeb.API.MessageService.ApiSetup;

namespace SIMSWeb.API.MessageService.App_Start
{
    public static class NinjectConfig
    {
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            IocMappings.ConfigureMappings(kernel);
            return kernel;
        }
    }
}