using Microsoft.EntityFrameworkCore;
using NZZwalks.Models.Domain;

namespace NZZwalks.DataContext
{
    public class AccountContext:DbContext
    {
        public AccountContext(DbContextOptions<AccountContext> opt):base(opt)
        {
            
        }


        public DbSet<Difficulty> Difficultes { get; set; }
        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //seed data for difficulty table
            //Easy, Medium, Hard

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id= Guid.Parse("e3b6568a-1119-4e30-bc8c-f7a4913818ec"),
                    Name= "Easy"
                },

                new Difficulty()
                {
                    Id= Guid.Parse("db804d2d-4ee6-4efc-947c-a8d0897c81f6"),
                    Name= "Medium"
                },

                new Difficulty()
                {
                    Id= Guid.Parse("75636fd6-b9ef-4733-b825-c86b113ff0f9"),
                    Name= "Hard"
                },
            };

            //sending difficulties to difficulty table in database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            //for region
            var regions = new List<Region>()
            {
                new Region()
                {
                    Id= Guid.Parse("7a26d1ff-e379-4df3-9e01-1c4180fcdc39"),
                    Name="Bay of Plenty",
                    Code="BOP",
                    RegionImgUlr="null"
                },
                new Region()
                {
                    Id= Guid.Parse("8e61003c-75a9-41dc-a8fd-fe63e87ebef8"),
                    Name="AuckLand",
                    Code="AKL",
                    RegionImgUlr="https://www.bing.com/images/search?view=detailV2&ccid=UkG89vab&id=371078079B0C47E89D79B33CEAB95F88E61D1DB6&thid=OIP.UkG89vab4fcyUBAA5VjC6gHaFP&mediaurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.5241bcf6f69be1f732501000e558c2ea%3frik%3dth0d5ohfueo8sw%26riu%3dhttp%253a%252f%252fwallpapercave.com%252fwp%252fsoSaTJM.jpg%26ehk%3dnUl6MV1yd74%252fP%252fWBLP%252b5aM%252fDbbp7HkpX1PCLIEK%252feVo%253d%26risl%3d%26pid%3dImgRaw%26r%3d0&exph=1700&expw=2400&q=nature+pics&simid=608044958947812527&FORM=IRPRST&ck=BA5A9B2E1D264AF298F494ADAEAB30BF&selectedIndex=0&itb=0&idpp=overlayview&ajaxhist=0&ajaxserp=0"
                },
                new Region()
                {
                    Id= Guid.Parse("5581f6b5-5324-496c-ac24-eea19275ad4d"),
                    Name="North Land",
                    Code="NL",
                    RegionImgUlr="null"
                }

            };

            //seed data
            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
