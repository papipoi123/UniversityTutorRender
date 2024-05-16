using Domain.Entities;

namespace Applications.ViewModels
{
    public class RoleViewModel
    {
        public string Rolename { get; set; }
    }

    public class GetRoleViewModel
    {
        public int Id { get; set; }
        public string Rolename { get; set; }
        public List<User>? Users { get; set; }
    }
}
