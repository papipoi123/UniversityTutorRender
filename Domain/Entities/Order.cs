using Domain.Base;
using Domain.Enums;

namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        public string TutorName { get; set; }
        public string StudentName { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal TotalPrice { get; set; }
        public int? StudentId { get; set; }
        public Student? Student { get; set; }
        public int? TutorId { get; set; }
        public Tutor? Tutor { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }
    }
}
