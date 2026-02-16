namespace Account.API.Services.Interfaces
{
    public interface IJwtTokenService
    {
        Task<string> GenerateToken(string phoneNumber);
        string GenerateGuestToken();
    }
}