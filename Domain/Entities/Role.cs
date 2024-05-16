using Domain.Base;

namespace Domain.Entities
{
    public class Role : BaseEntity
    {
        public string Rolename { get; set; }
        public List<User>? Users { get; set; }
    }
}
