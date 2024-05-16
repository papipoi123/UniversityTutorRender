using Applications.Commons;

namespace Applications.Interfaces
{
    public interface IMailService
    {
        Task<Response> SendAsync(string email);
    }
}
