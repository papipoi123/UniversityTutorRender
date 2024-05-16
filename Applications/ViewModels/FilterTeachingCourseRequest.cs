using Domain.Enums;

namespace Applications.ViewModels
{
    public class FilterTeachingCourseRequest
    {
        public string? CourseName { get; set; }
        public List<int>? DurationType { get; set; }
        public TeachingType? TeachingType { get; set; }
        public List<int>? StartDateType { get; set; }
        public decimal? StartPrice { get; set; }
        public decimal? EndPrice { get; set; }
        public List<int>? CourseMajorId { get; set; }
        public List<double>? AvgRating { get; set; }
    }
}
