using Ninject;
using SIMSWeb.API1.ApiSetup;

namespace SIMSWeb.API1.App_Start
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