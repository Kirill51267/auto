using auto.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace auto.Domain
{
    public class ApplicationContext: IdentityDbContext<IdentityUser>
    {
        public DbSet<Brand>? Brands { get; set; }

        public DbSet<Model>? Models { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

    }
}
