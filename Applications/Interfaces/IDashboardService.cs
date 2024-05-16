using Applications.Commons;

namespace Applications.Interfaces
{
    public interface IDashboardService
    {
        Response GetTutor();
        Response GetStudent();
        Response GetTutorInMonth();
        Response GetStudentInMonth();
        Response GetCourseSelled();
        Response GetOrderInMonth();
        Response GetCourseCreatedInMonth();
    }
}
