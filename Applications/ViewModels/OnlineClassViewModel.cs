using Domain.Entities;

namespace Applications.ViewModels
{
    public class GetOnlineClassViewModel
    {
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        public int TeachingCourseId { get; set; }
        public TeachingCourse? TeachingCourse { get; set; }
    }
}
