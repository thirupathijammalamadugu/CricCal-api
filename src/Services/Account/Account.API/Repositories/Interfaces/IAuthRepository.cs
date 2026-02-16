using Account.API.Entities;

namespace Account.API.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<string> RequestOtpAsync(string phoneNumber);

        Task<User> GetUserAsync(string phoneNumber);
    }
}