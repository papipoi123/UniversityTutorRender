namespace Applications.ViewModels
{
    public class AdminViewModel
    {

    }

    public class GetAdminViewModel: AdminViewModel
    {
        public int Id { get; set; }
        public GetUserViewModel? User { get; set; }
    }
}
