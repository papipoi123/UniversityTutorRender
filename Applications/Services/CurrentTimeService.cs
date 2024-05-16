using Applications.Interfaces;

namespace Applications.Services
{
    public class CurrentTimeService : ICurrentTimeService
    {
        public DateTime GetCurrentTime() => DateTime.UtcNow;
    }
}
