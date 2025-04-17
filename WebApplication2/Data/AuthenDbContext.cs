using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models.Domain;
namespace WebApplication2.Data
{
    public class AuthenDbContext:IdentityDbContext<User>
    {
        public AuthenDbContext(DbContextOptions<AuthenDbContext> options) : base(options) 
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); //lệnh khởi tạo
            SeedRoles(builder); // lệnh tạo roles
        }
        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" },
                new IdentityRole() { Name = "Editor", ConcurrencyStamp = "3", NormalizedName = "Editor" }
                );
        }
    }

}
