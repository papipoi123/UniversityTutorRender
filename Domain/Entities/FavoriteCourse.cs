using Domain.Base;

namespace Domain.Entities
{
    public class FavoriteCourse : BaseEntity
    {
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        public int TeachingCourseId { get; set; }
        public TeachingCourse? TeachingCourse { get; set; }
    }
}
