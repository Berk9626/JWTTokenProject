using Berk.JwtApp.Back.Core.Domain;
using Berk.JwtApp.Back.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Berk.JwtApp.Back.Persistance.Context
{
    public class JWTContext: DbContext
    {
        public JWTContext(DbContextOptions<JWTContext> options): base(options)
        {


        }

        DbSet<AppRole>? AppRoles => this.Set<AppRole>();
        DbSet<AppUser>? AppUsers => this.Set<AppUser>();
        DbSet<Category>? Categories => this.Set<Category>();
        DbSet<Product>? Products => this.Set<Product>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            base.OnModelCreating(modelBuilder); 
        }



    }
}
