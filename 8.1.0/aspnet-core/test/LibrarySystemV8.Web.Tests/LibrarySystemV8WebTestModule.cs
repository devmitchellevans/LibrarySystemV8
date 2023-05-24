using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LibrarySystemV8.EntityFrameworkCore;
using LibrarySystemV8.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace LibrarySystemV8.Web.Tests
{
    [DependsOn(
        typeof(LibrarySystemV8WebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class LibrarySystemV8WebTestModule : AbpModule
    {
        public LibrarySystemV8WebTestModule(LibrarySystemV8EntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LibrarySystemV8WebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(LibrarySystemV8WebMvcModule).Assembly);
        }
    }
}