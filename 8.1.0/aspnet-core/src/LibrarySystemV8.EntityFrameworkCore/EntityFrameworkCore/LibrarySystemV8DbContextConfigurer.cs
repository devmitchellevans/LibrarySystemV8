using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystemV8.EntityFrameworkCore
{
    public static class LibrarySystemV8DbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<LibrarySystemV8DbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<LibrarySystemV8DbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
