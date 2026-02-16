namespace Account.API.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> RequestOtpAsync(string phoneNumber);
        Task<string> VerifyOtpAndGetTokenAsync(string phoneNumber, string otp);
    }
}