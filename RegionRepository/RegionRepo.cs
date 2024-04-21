using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using NZZwalks.DataContext;
using NZZwalks.Models.Domain;

namespace NZZwalks.RegionRepository
{
    public class RegionRepo : IRegionRepo
    {
        private readonly AccountContext dbcontext;

        public RegionRepo(AccountContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<Region> Create(Region region)
        {
            await dbcontext.Regions.AddAsync(region);
            await dbcontext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> Delete(Guid id)
        {
            var olddata = await dbcontext.Regions.FirstOrDefaultAsync(r=>r.Id == id);
            if (olddata == null)
            {
                return null;
            }
            dbcontext.Regions.Remove(olddata);
            await dbcontext.SaveChangesAsync();
            return olddata;
        }

        public async Task<List<Region>> GetAllRegions()
        {
            var data = await dbcontext.Regions.ToListAsync();
            if(data == null)
            {
                return null;
            }
            return data;
        }

        public async Task<Region?> GetRegion(Guid id)
        {
            var data = await dbcontext.Regions.FirstOrDefaultAsync(r => r.Id == id);
            if(data == null)
            {
                return null;
            }
            return data;
        }

        public async Task<Region> Update(Guid id, Region region)
        {
            var oldData = await dbcontext.Regions.FirstOrDefaultAsync(r => r.Id == id);
            if(oldData == null)
            {
                return null;
            }
            oldData.Name = region.Name;
            oldData.Code = region.Code;
            oldData.RegionImgUlr = region.RegionImgUlr;
            await dbcontext.SaveChangesAsync();
            return oldData;
        }
    }
}
