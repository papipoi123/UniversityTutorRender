using Applications.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly AppDbContext _context;

        public DashboardRepository(AppDbContext context)
        {
            _context = context;
        }

        public int GetCourseCreatedInMonth()
        {
            var order = _context.TeachingCourses.Count(x => x.CreationDate.Month == DateTime.Now.Month);
            return order;
        }

        public int GetCourseSelled()
        {
            var order = _context.Orders.Count(x => x.OrderStatus == Domain.Enums.OrderStatus.Completed);
            return order;
        }

        public int GetOrderInMonth()
        {
            var order = _context.Orders.Count(x => x.OrderDate.Month == DateTime.Now.Month);
            return order;
        }

        public int GetStudent()
        {
            var student = _context.Students.Where(x => x.IsDeleted == false).Count();
            return student;
        }

        public int GetStudentInMonth()
        {
            var student = _context.Students.Where(x => x.IsDeleted == false).Count(x => x.CreatedAt.Month == DateTime.Now.Month);
            return student;
        }

        public int GetTutor()
        {
            var tutor = _context.Tutors.Where(x => x.IsDeleted == false).Count();
            return tutor;
        }

        public int GetTutorInMonth()
        {
            var tutor = _context.Tutors.Where(x => x.IsDeleted == false).Count(x => x.CreatedAt.Month == DateTime.Now.Month);
            return tutor;
        }
    }
}
