namespace Applications.Interfaces
{
    public interface IClaimsServices
    {
        string? GetCurrentUser();
        int GetCurrentUserId();
    }
}
