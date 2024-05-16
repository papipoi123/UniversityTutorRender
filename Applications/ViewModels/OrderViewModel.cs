using Domain.Entities;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Applications.ViewModels
{
    public class OrderViewModel 
    {
        public string TutorName { get; set; }
        public string StudentName { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now; 
        public OrderStatus OrderStatus { get; set; }
        public decimal TotalPrice { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; } = default!;
        public List<OrderDetailViewModel>? OrderDetails { get; set; }
    }
}