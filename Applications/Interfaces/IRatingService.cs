using Applications.Commons;
using Applications.ViewModels;

namespace Applications.Interfaces
{
    public interface IRatingService
    {
        Task<Response> GetRatingInfor(int id);
        Task<Response> GetAllRating(int pageIndex = 0, int pageSize = 10);
        Task<Response> CreateRating(RatingViewModel model);
        Task<Response> UpdateRating(int id, RatingViewModel model);
        Task<Response> RemoveRating(int id);
    }
}
