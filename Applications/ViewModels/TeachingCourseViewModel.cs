using Domain.Entities;
using Domain.Enums;

namespace Applications.ViewModels
{
    public class TeachingCourseViewModel 
    {
        public string CourseName { get; set; } = default!;
        public int Duration { get; set; }
        public int TotalWeek { get; set; }
        public TeachingType TeachingType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal CoursePrice { get; set; }
        public string Description { get; set; } = default!;
        public string SyllabusFile { get; set; } = default!;
        public string CourseSampleVideo { get; set; } = default!;
        public int TotalStudent { get; set; }
        public double RatingStar { get; set; }
        public string? CourseImage { get; set; }
        public AllowJoiningClass AllowJoiningClass { get; set; }
        public CourseType CourseType { get; set; }
        public string CourseFile { get; set; } = default!;
        public CourseStatus CourseStatus { get; set; }
        public string ClassLocation { get; set; } = default!;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public int TutorId { get; set; }
        public int UniversityId { get; set; }
        public int CourseMajorId { get; set; }
        public IList<UnitViewModel?> Units { get; set; }
        public UniversityViewModel? Universities { get; set; }
        public CourseMajorViewModel? CourseMajor { get; set; }
    }

    public class GetTeachingCourseViewModel
    {
        public int Id { get; set; }
        public string CourseName { get; set; } = default!;
        public int Duration { get; set; }
        public int TotalWeek { get; set; }
        public TeachingType TeachingType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal CoursePrice { get; set; }
        public string Description { get; set; } = default!;
        public string SyllabusFile { get; set; } = default!;
        public string CourseSampleVideo { get; set; } = default!;
        public int TotalStudent { get; set; }
        public double RatingStar { get; set; }
        public string? CourseImage { get; set; }
        public AllowJoiningClass AllowJoiningClass { get; set; }
        public CourseType CourseType { get; set; }
        public string CourseFile { get; set; } = default!;
        public CourseStatus CourseStatus { get; set; }
        public string ClassLocation { get; set; } = default!;
        public DateTime CreationDate { get; set; }
        public int? CreatedBy { get; set; }
        public int TutorId { get; set; }
        public int UniversityId { get; set; }
        public int CourseMajorId { get; set; }
        public List<UnitViewModel?> Units { get; set; }
        public UniversityViewModel? Universities { get; set; }
        public CourseMajorViewModel? CourseMajor { get; set; }
    }
}