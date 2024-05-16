using Domain.Base;

namespace Domain.Entities
{
    public class Student : BaseEntity
    {
        public string? SelfDescription { get; set; }
        public int? TotalCourseLearned { get; set; }
        public DateTime CreatedAt { get; set; }
        public User? User { get; set; }
        public List<OnlineClass>? OnlineClasses { get; set; }
        public List<Rating>? Ratings { get; set; }
        public List<Order>? Orders { get; set; }
        public List<TutorFeedback>? TutorFeedbacks { get; set; }
        public List<FavoriteCourse>? FavoriteCourses { get; set; }
    }
}
