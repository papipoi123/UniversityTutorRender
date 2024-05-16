using Applications.Interfaces;
using Applications.Repositories;

namespace Applications
{
    public interface IUnitOfWork
    {
        public Task<int> SaveChangeAsync();
        public IUserRepository UserRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public IStudentRepository StudentRepository { get; }
        public IUniversityRepository UniversityRepository { get; }
        public ICourseMajorRepository CourseMajorRepository { get; }
        public ITutorRepository TutorRepository { get; }
        public IWeeklyTimeRepository WeeklyTimeRepository { get; }
        public IReportRepository ReportRepository { get; }
        public ITeachingCourseRepository TeachingCourseRepository { get; }
        public ITransactionRepository TransactionRepository { get; }

        public ITutorFeedbackRepository TutorFeedbackRepository { get; }
        public ICertificationRepository CertificationRepository { get; }
        public IAdminRepository AdminRepository { get; }
        public IFavoriteCourseRepository FavoriteCourseRepository { get; }
        public IOnlineClassRepository OnlineClassRepository { get; }
        public IRatingRepository RatingRepository { get; }
        public IRoleRepository RoleRepository { get; }
        public IWalletRepository WalletRepository { get; }
        public IDashboardRepository DashboardRepository { get; }
    }
}
