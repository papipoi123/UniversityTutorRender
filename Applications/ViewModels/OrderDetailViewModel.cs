using Domain.Entities;

namespace Applications.ViewModels
{
    public class OrderDetailViewModel 
    {
        public int OrderId { get; set; }
        public OrderViewModel? Order { get; set; }
        public int TeachingCourseId { get; set; }
        public TeachingCourseViewModel? TeachingCourse { get; set; }
    }
}