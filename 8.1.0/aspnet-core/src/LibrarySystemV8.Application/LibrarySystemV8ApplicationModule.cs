using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LibrarySystemV8.Authorization;

namespace LibrarySystemV8
{
    [DependsOn(
        typeof(LibrarySystemV8CoreModule), 
        typeof(AbpAutoMapperModule))]
    public class LibrarySystemV8ApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<LibrarySystemV8AuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(LibrarySystemV8ApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
