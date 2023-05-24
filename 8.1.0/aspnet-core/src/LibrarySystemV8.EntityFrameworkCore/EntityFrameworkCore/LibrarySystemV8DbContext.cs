using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using LibrarySystemV8.Authorization.Roles;
using LibrarySystemV8.Authorization.Users;
using LibrarySystemV8.MultiTenancy;
using LibrarySystemV8.Entities;

namespace LibrarySystemV8.EntityFrameworkCore
{
    public class LibrarySystemV8DbContext : AbpZeroDbContext<Tenant, Role, User, LibrarySystemV8DbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<BookCategory> BookCategories { get; set; }
        public virtual DbSet<Borrower> Borrowers { get; set; }
        public LibrarySystemV8DbContext(DbContextOptions<LibrarySystemV8DbContext> options)
            : base(options)
        {
        }
    }
}
