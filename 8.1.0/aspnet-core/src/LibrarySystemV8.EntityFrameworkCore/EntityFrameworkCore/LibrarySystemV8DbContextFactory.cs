using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using LibrarySystemV8.Configuration;
using LibrarySystemV8.Web;

namespace LibrarySystemV8.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class LibrarySystemV8DbContextFactory : IDesignTimeDbContextFactory<LibrarySystemV8DbContext>
    {
        public LibrarySystemV8DbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<LibrarySystemV8DbContext>();
            
            /*
             You can provide an environmentName parameter to the AppConfigurations.Get method. 
             In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
             Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
             https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
             */
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            LibrarySystemV8DbContextConfigurer.Configure(builder, configuration.GetConnectionString(LibrarySystemV8Consts.ConnectionStringName));

            return new LibrarySystemV8DbContext(builder.Options);
        }
    }
}
