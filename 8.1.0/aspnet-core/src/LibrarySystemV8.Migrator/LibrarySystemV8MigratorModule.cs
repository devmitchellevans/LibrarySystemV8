using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LibrarySystemV8.Configuration;
using LibrarySystemV8.EntityFrameworkCore;
using LibrarySystemV8.Migrator.DependencyInjection;

namespace LibrarySystemV8.Migrator
{
    [DependsOn(typeof(LibrarySystemV8EntityFrameworkModule))]
    public class LibrarySystemV8MigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public LibrarySystemV8MigratorModule(LibrarySystemV8EntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(LibrarySystemV8MigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                LibrarySystemV8Consts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LibrarySystemV8MigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
