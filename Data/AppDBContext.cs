using Gadget.api.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Gadget.api.Data
{
    public class AppDBContext : IdentityDbContext<ApplicationUser>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options): base(options)
        {

        }

        public DbSet<Gadgets> Gadgets { get; set; }
        public DbSet<GadgetUser> GadgetUsers { get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(entity =>
           {
                entity.ToTable(name: "ApplicationUsers");
                entity.Property(x => x.Status).HasMaxLength(50).HasConversion<string>();
                entity.Property(x => x.LastName).IsRequired().HasMaxLength(250);
                entity.Property(x => x.FirstName).IsRequired().HasMaxLength(250);
                entity.Property(x => x.MiddleName).IsRequired().HasMaxLength(250);
            
           });

           builder.Entity<ApplicationRole>(entity =>
           {
               entity.ToTable(name: "ApplicationRole");
               entity.Property(x => x.Status).HasMaxLength(50).HasConversion<string>();
               entity.Property(x => x.Description).HasMaxLength(500);

           });

           builder.Entity<IdentityUserRole<string>>(entity =>
           {
               entity.ToTable(name: "ApplicationUserRoles");
           });

           builder.Entity<IdentityRoleClaim<string>>(entity =>
           {
               entity.ToTable(name: "ApplicationRoleClaims");
           });

           builder.Entity<IdentityUserLogin<string>>(entity =>
           {
               entity.ToTable(name: "ApplicationUserLogins");
           });

           builder.Entity<IdentityUserToken<string>>(entity =>
           {
               entity.ToTable(name: "ApplicationUserTokens");
           });

        }

    }
}
