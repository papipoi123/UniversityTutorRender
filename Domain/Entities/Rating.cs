using Domain.Base;

namespace Domain.Entities
{
    public class Rating : BaseEntity
    {
        public int RatingStar { get; set; }
        public string Feedback { get; set; }
        public DateTime CreationDate { get; set; }
        public int? CreatedBy { get; set; }
        public int TeachingCourseId { get; set; }
        public TeachingCourse? TeachingCourse { get; set; }
        public int StudentId { get; set; }
        public Student? Student { get; set; }
    }
}
