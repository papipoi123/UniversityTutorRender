using Applications.Interfaces;
using Applications.Repositories;
using Domain.Entities;

namespace Infrastructures.Repositories
{
    public class CertificationRepository : GenericRepository<Certification>, ICertificationRepository
    {
        public CertificationRepository(AppDbContext context, ICurrentTimeService currentTime, IClaimsServices claimsServices) : base(context, currentTime, claimsServices)
        {
        }
    }
}
