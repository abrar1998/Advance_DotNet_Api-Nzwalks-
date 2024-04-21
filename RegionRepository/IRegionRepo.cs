using NZZwalks.Models.Domain;

namespace NZZwalks.RegionRepository
{
    public  interface IRegionRepo
    {
        Task<List<Region>> GetAllRegions();
        Task<Region?> GetRegion(Guid id);

        Task<Region> Create(Region region);

        Task<Region> Update(Guid id , Region region);
        Task<Region> Delete(Guid id);
    }
}
