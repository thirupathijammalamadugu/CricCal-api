using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Account.API.Services.Interfaces;
using Account.API.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Account.API.Services
{
    

    public class JwtTokenService : IJwtTokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthRepository _authRepository;

        public JwtTokenService(IConfiguration configuration, IAuthRepository authRepository)
        {
            _configuration = configuration;
            _authRepository = authRepository;
        }

        public async Task<string> GenerateToken(string phoneNumber)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"];
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];
            var expirationMinutes = int.Parse(jwtSettings["ExpirationMinutes"] ?? "60");
            var role = "user";
            var permissions = new[] { "read", "write" };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var user = await _authRepository.GetUserAsync(phoneNumber);
            var userId = user.UserId.ToString();

            var claimsList = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId ?? Guid.Empty.ToString()),
                new Claim(ClaimTypes.MobilePhone, phoneNumber),
                new Claim(ClaimTypes.Role, role),
                new Claim("iss", issuer ?? ""),
            };

            // Add permission claims
            foreach (var permission in permissions)
            {
                claimsList.Add(new Claim("permission", permission));
            }

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claimsList,
                expires: DateTime.UtcNow.AddMinutes(expirationMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    public string GenerateGuestToken()
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"];
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];
            var expirationMinutes = int.Parse(jwtSettings["ExpirationMinutes"] ?? "60");
            var role = "guest";
            var permissions = new[] { "read" };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claimsList = new List<Claim>
            {
                new Claim(ClaimTypes.Role, role),
                new Claim("iss", issuer ?? ""),
            };

            // Add permission claims
            foreach (var permission in permissions)
            {
                claimsList.Add(new Claim("permission", permission));
            }

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claimsList,
                expires: DateTime.UtcNow.AddMinutes(expirationMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
