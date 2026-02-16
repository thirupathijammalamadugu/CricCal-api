using Account.API.Repositories.Interfaces;
using Account.API.Services.Interfaces;

namespace Account.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthService(IAuthRepository authRepository, IJwtTokenService jwtTokenService)
        {
            _authRepository = authRepository;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<string> RequestOtpAsync(string phoneNumber)
        {
            return await _authRepository.RequestOtpAsync(phoneNumber);
        }

        public async Task<string> VerifyOtpAndGetTokenAsync(string phoneNumber, string otp)
        {
            // TODO: Verify OTP from repository/database
            // For now, we'll assume OTP verification is successful
            // In production, validate the OTP against stored value
            
            var token = await _jwtTokenService.GenerateToken(phoneNumber);
            
            return token;
        }
    }
}