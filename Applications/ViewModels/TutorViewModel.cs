using Domain.Entities;
using Domain.Enums;

namespace Applications.ViewModels
{
    public class TutorViewModel
    {
        public string? SelfDescription { get; set; }
        public string? ExampleVideoStyle { get; set; }
        public int? AvgRatingStar { get; set; }
        public TutorAuthorize? TutorAuthorize { get; set; }
        public string? TutorLocation { get; set; } = default!;
        public int? TutorCourseSold { get; set; }
    }

    public class GetTutorViewModel
    {
        public int Id { get; set; }
        public string SelfDescription { get; set; }
        public string ExampleVideoStyle { get; set; }
        public int AvgRatingStar { get; set; }
        public TutorAuthorize TutorAuthorize { get; set; }
        public string TutorLocation { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public int TutorCourseSold { get; set; }
        public GetUserViewModel? User { get; set; }
        public List<Certification>? Certifications { get; set; }
        public List<TutorFeedback>? TutorFeedbacks { get; set; }
        public List<TeachingCourse>? TeachingCourses { get; set; }
    }

    public class TutorViewModelForRegis
    {
        public AcademicLevel? AcademicLevel { get; set; }
        public string? TutorLocation { get; set; }
    }

    public class UpdateTutorViewModel
    {
        public string? SelfDescription { get; set; }
        public string? ExampleVideoStyle { get; set; }
        public int? AvgRatingStar { get; set; }
        public TutorAuthorize? TutorAuthorize { get; set; }
        public string? TutorLocation { get; set; } = default!;
        public int? TutorCourseSold { get; set; }
        public UpdateUserViewModel? User { get; set; }
    }
}
