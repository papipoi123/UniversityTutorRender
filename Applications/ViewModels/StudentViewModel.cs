using Domain.Entities;

namespace Applications.ViewModels
{
    public class StudentViewModel
    {
        public string? SelfDescription { get; set; }
        public int? TotalCourseLearned { get; set; }
    }

    public class GetStudentViewModel
    {
        public int Id { get; set; }
        public string SelfDescription { get; set; }
        public int TotalCourseLearned { get; set; }
        public DateTime CreatedAt { get; set; }
        public GetUserViewModel? User { get; set; }
    }

    public class UpdateStudentViewModel
    {
        public string? SelfDescription { get; set; }
        public int? TotalCourseLearned { get; set; }
        public UpdateUserViewModel? User { get; set; }
    }
}
