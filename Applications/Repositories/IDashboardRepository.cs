namespace Applications.Repositories
{
    public interface IDashboardRepository
    {
        int GetTutor();
        int GetStudent();
        int GetTutorInMonth();
        int GetStudentInMonth();
        int GetCourseSelled();
        int GetOrderInMonth();
        int GetCourseCreatedInMonth();
    }
}
