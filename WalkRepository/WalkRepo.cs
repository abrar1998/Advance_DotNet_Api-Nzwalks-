using Microsoft.EntityFrameworkCore;
using NZZwalks.DataContext;
using NZZwalks.Models.Domain;

namespace NZZwalks.WalkRepository
{
    public class WalkRepo : IWalkRepo
    {
        private readonly AccountContext dbcontext;

        public WalkRepo(AccountContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task<Walk> AddWalk(Walk walk)
        {
            await dbcontext.Walks.AddAsync(walk);
            await dbcontext.SaveChangesAsync();
            return walk;
        }

        public async Task<List<Walk>> GetAllWalks(string? filteron = null, string? filterquery = null,
            string? sortBy = null, bool? IsAscending = true, int PageNumber = 1, int PageSize = 1000)
        {
            var getWalk =  dbcontext.Walks.Include("Difficulty").Include("Region").AsQueryable();
            //filtering
            if (String.IsNullOrWhiteSpace(filteron) == false && String.IsNullOrWhiteSpace(filterquery) == false)
            {
                if(filteron.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    getWalk = getWalk.Where(x => x.Name.Contains(filterquery));
                }
            }
            //apply sorting

            if(String.IsNullOrWhiteSpace(sortBy) == false)
            {
                if(sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    getWalk = (bool) IsAscending ? getWalk.OrderBy(x => x.Name) : getWalk.OrderByDescending(x => x.Name);
                }
                else if(sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
                {
                    getWalk = (bool) IsAscending ? getWalk.OrderBy(x => x.LengthInkm) : getWalk.OrderByDescending(x => x.LengthInkm);
                }
            }

            //pagination

            var skipResults = (PageNumber - 1) * PageSize;
            return await getWalk.Skip(skipResults).Take(PageSize).ToListAsync();

            /*return await getWalk.ToListAsync();*/
        }

        public async Task<Walk> GetWalk(Guid id)
        {
            var walk = await dbcontext.Walks.Include("Difficulty").Include("Region").Where(w=>w.Id == id).FirstOrDefaultAsync();
            if(walk == null)
            {
                return null;
            }
            return walk;
        }

        public async Task<Walk> WalkUpdate(Guid id, Walk _walk)
        {
            var oldData = await dbcontext.Walks.Where(w=>w.Id ==  id).FirstOrDefaultAsync();
            if(oldData == null)
            {
                return null;
            }

            oldData.Name = _walk.Name;
            oldData.LengthInkm = _walk.LengthInkm;
            oldData.WalkImgUrl = _walk.WalkImgUrl;
            oldData.RegionId = _walk.RegionId;
            oldData.DifficultyId = _walk.DifficultyId;
            //dbcontext.Update(oldData);
            await dbcontext.SaveChangesAsync();
            return oldData; 

        }
    }
}
