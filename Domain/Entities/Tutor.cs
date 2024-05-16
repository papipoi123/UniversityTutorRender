using Domain.Base;
using Domain.Enums;

namespace Domain.Entities
{
    public class Tutor : BaseEntity
    {
        public string? SelfDescription { get; set; }
        public string? ExampleVideoStyle { get; set; }
        public int? AvgRatingStar { get; set; }
        public TutorAuthorize? TutorAuthorize { get; set; }
        public AcademicLevel? AcademicLevel { get; set; }
        public string? TutorLocation { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? TutorCourseSold { get; set; }
        public User? User { get; set; }
        public List<Certification>? Certifications { get; set; }
        public List<TutorFeedback>? TutorFeedbacks { get; set; }
        public List<TeachingCourse>? TeachingCourses { get; set; }
        public List<Order>? Orders { get; set; }
    }
}
