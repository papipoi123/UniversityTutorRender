using Applications;
using Applications.Interfaces;
using Applications.Repositories;
using Infrastructures.Repositories;

namespace Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly ICurrentTimeService _currentTimeService;
        private readonly IClaimsServices _claimsServices;

        public UnitOfWork(AppDbContext context,
                          ICurrentTimeService currentTimeService,
                          IClaimsServices claimsServices)
        {
            _context = context;
            _currentTimeService = currentTimeService;
            _claimsServices = claimsServices;
        }

        public IUserRepository UserRepository => new UserRepository(_context, _currentTimeService, _claimsServices);

        public IOrderRepository OrderRepository => new OrderRepository(_context,_currentTimeService,_claimsServices);
        public IUniversityRepository UniversityRepository => new UniversityRepository(_context, _currentTimeService, _claimsServices);
        public ITutorRepository TutorRepository => new TutorRepository(_context, _currentTimeService, _claimsServices);
        public IStudentRepository StudentRepository => new StudentRepository(_context, _currentTimeService, _claimsServices);
        public ICourseMajorRepository CourseMajorRepository => new CourseMajorRepository(_context, _currentTimeService, _claimsServices);
        public ITeachingCourseRepository TeachingCourseRepository => new TeachingCourseRepository(_context, _currentTimeService, _claimsServices);
        public IReportRepository ReportRepository => new ReportRepository(_context, _currentTimeService, _claimsServices);
        public IWeeklyTimeRepository WeeklyTimeRepository => new WeeklyTimeRepository(_context, _currentTimeService, _claimsServices);
        public ITutorFeedbackRepository TutorFeedbackRepository => new TutorFeedbackRepository(_context, _currentTimeService, _claimsServices);
        public ITransactionRepository TransactionRepository => new TransactionRepository(_context, _currentTimeService, _claimsServices);

        public ICertificationRepository CertificationRepository => new CertificationRepository(_context, _currentTimeService, _claimsServices);

        public IAdminRepository AdminRepository => new AdminRepository(_context, _currentTimeService, _claimsServices);

        public IFavoriteCourseRepository FavoriteCourseRepository => new FavoriteCourseRepository(_context, _currentTimeService, _claimsServices);

        public IOnlineClassRepository OnlineClassRepository => new OnlineClassRepository(_context, _currentTimeService, _claimsServices);

        public IRatingRepository RatingRepository => new RatingRepository(_context, _currentTimeService, _claimsServices);

        public IRoleRepository RoleRepository => new RoleRepository(_context, _currentTimeService, _claimsServices);

        public IDashboardRepository DashboardRepository => new DashboardRepository(_context);
        public IWalletRepository WalletRepository => new WalletRepository(_context, _currentTimeService, _claimsServices);

        public async Task<int> SaveChangeAsync() => await _context.SaveChangesAsync();
    }
}
