using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LibrarySystemV8.Configuration;

namespace LibrarySystemV8.Web.Host.Startup
{
    [DependsOn(
       typeof(LibrarySystemV8WebCoreModule))]
    public class LibrarySystemV8WebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public LibrarySystemV8WebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LibrarySystemV8WebHostModule).GetAssembly());
        }
    }
}
