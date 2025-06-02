using AcademiaOnline.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AcademiaOnline.Infrastructure.Persistence.Data.Identity
{


    public class ApplicationSecurityDbContext : IdentityDbContext<TbUsuario, ApplicationRole, string>
    {
        public ApplicationSecurityDbContext(DbContextOptions<ApplicationSecurityDbContext> options)
            : base(options)
        {
        }
    }

    public class ApplicationSecurityDbContextFactory : IDesignTimeDbContextFactory<ApplicationSecurityDbContext>
    {
        public ApplicationSecurityDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationSecurityDbContext>();
            optionsBuilder.UseSqlServer("ConexionDatabase");

            return new ApplicationSecurityDbContext(optionsBuilder.Options);
        }
    }
}
