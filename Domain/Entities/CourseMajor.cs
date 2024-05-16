using Domain.Base;

namespace Domain.Entities
{
    public class CourseMajor : BaseEntity
    {
        public string CourseMajorName { get; set; }
        public List<TeachingCourse>? TeachingCourses { get; set; }

    }
}
