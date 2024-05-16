using Domain.Base;

namespace Domain.Entities
{
    public class Admin : BaseEntity
    {
        public User? User { get; set; }
    }
}
