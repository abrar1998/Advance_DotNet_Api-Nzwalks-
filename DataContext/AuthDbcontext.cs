using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZZwalks.DataContext
{
    public class AuthDbcontext : IdentityDbContext
    {
        public AuthDbcontext(DbContextOptions<AuthDbcontext> opt) : base(opt)
        {

        }

        //adding roles 
        //data seeding
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerId = "64401709-130e-452a-afea-22cc84396e17";
            var writerId = "4d8ad408-fa0d-42e1-a586-35d045a79984";

            var roles = new List<IdentityRole>()
            {
                new IdentityRole
                {
                    Id = readerId,
                    ConcurrencyStamp = readerId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },

                new IdentityRole
                {
                    Id=writerId,
                    ConcurrencyStamp = readerId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);  
        }
    }
}
