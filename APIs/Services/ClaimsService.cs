using Applications.Interfaces;

namespace APIs.Services
{
    public class ClaimsService : IClaimsServices
    {
        public ClaimsService(IHttpContextAccessor httpContext)
        {
            var id = httpContext.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type == "Id")?.Value;
            _currentUser = id;
        }
        private string? _currentUser { get; }
        public string? GetCurrentUser() => _currentUser;
        public int GetCurrentUserId() => Convert.ToInt32(_currentUser); //if id==null, id=0 
    }
}
