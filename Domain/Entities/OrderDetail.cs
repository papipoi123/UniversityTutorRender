using Domain.Base;

namespace Domain.Entities
{
    public class OrderDetail : BaseEntity
    {
        public int OrderId { get; set; }
        public Order? Order { get; set; }
        public int TeachingCourseId { get; set; }
        public TeachingCourse? TeachingCourse { get; set; }
    }
}
