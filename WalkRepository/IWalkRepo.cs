using NZZwalks.Models.Domain;
using System.Globalization;

namespace NZZwalks.WalkRepository
{
    public interface IWalkRepo
    {
        Task<Walk> AddWalk(Walk walk);
        Task<List<Walk>> GetAllWalks(string? filteron = null, string? filterquery = null, string? sortBy= null, bool? IsAscending = true, int PageNumber = 1 , int  PageSize = 1000);
        Task<Walk? > GetWalk(Guid id);
        Task<Walk> WalkUpdate(Guid id, Walk _walk);
    }
}
