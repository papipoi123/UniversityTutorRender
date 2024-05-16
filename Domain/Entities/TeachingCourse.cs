using Domain.Base;
using Domain.Enums;

namespace Domain.Entities
{
    public class TeachingCourse : BaseEntity
    {
        public string CourseName { get; set; }
        public int Duration { get; set; }
        public int TotalWeek { get; set; }  
        public TeachingType TeachingType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal CoursePrice { get; set; }
        public string Description { get; set; }
        public string SyllabusFile { get; set; }
        public string CourseSampleVideo { get; set; }
        public int TotalStudent { get; set; }
        public double RatingStar { get; set; }
        public string? CourseImage { get; set; }
        public AllowJoiningClass AllowJoiningClass { get; set; }
        public CourseType CourseType { get; set; }
        public string CourseFile { get; set; }
        public CourseStatus CourseStatus { get; set; }
        public string ClassLocation { get; set; }
        public DateTime CreationDate { get; set; }
        public int? CreatedBy { get; set; }
        public int TutorId { get; set; }
        public Tutor? Tutor { get; set; }
        public int UniversityId { get; set; }
        public University? University { get; set; }
        public int CourseMajorId { get; set; }
        public CourseMajor? CourseMajor { get; set; }
        public List<OnlineClass>? OnlineClasses { get; set; }
        public List<Unit>? Units { get; set; }
        public List<Rating>? Ratings { get; set; }
        public List<WeeklyTime>? WeeklyTimes { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }
        public List<FavoriteCourse>? FavoriteCourses { get; set; }
    }
}
