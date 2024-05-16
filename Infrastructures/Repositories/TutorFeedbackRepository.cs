using Applications.Interfaces;
using Applications.Repositories;
using Domain.Entities;

namespace Infrastructures.Repositories
{
    public class TutorFeedbackRepository : GenericRepository<TutorFeedback>, ITutorFeedbackRepository
    {
        public TutorFeedbackRepository(AppDbContext context, ICurrentTimeService currentTime, IClaimsServices claimsServices) : base(context, currentTime, claimsServices)
        {
        }
    }
}
