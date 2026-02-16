using Account.API.Contracts.Requests;
using Account.API.Contracts.Responses;
using Account.API.Services.Interfaces;
using Carter;
using Microsoft.AspNetCore.Mvc;

namespace Account.API.Controllers
{
    public class AuthController : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/v1/auth")
                .WithTags("Auth");

            group.MapPost("/request-otp", RequestOtpAsync)
                .WithName("RequestOtp")
                .Produces<string>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Request OTP")
                .WithDescription("Request an OTP for user authentication");

            group.MapPost("/verify-otp", VerifyOtpAsync)
                .WithName("VerifyOtp")
                .Produces<VerifyOtpResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Verify OTP")
                .WithDescription("Verify the OTP for user authentication");

            group.MapGet("/guest-token", GenerateGuestTokenAsync)
                .WithName("GenerateGuestToken")
                .Produces<string>(StatusCodes.Status200OK)
                .WithSummary("Generate Guest Token")
                .WithDescription("Generate a JWT token for guest users");
        }

        private async Task<IResult> RequestOtpAsync([FromBody] RequestOtpRequest requestOtpRequest, IAuthService authService)
        {
            if (string.IsNullOrEmpty(requestOtpRequest.PhoneNumber))
            {
                return Results.BadRequest(new { message = "Phone number is required" });
            }

            var result = await authService.RequestOtpAsync(requestOtpRequest.PhoneNumber);

            return Results.Ok(result);
        }

        private async Task<IResult> VerifyOtpAsync([FromBody] VerifyOtpRequest verifyOtpRequest, IJwtTokenService jwtTokenService)
        {
            if (string.IsNullOrEmpty(verifyOtpRequest.PhoneNumber) || string.IsNullOrEmpty(verifyOtpRequest.Otp))
            {
                return Results.BadRequest(new { message = "Phone number and OTP are required" });
            }
            if (!string.IsNullOrEmpty(verifyOtpRequest.Purpose) && (verifyOtpRequest.Purpose.ToLower() == "auth"))
            {
                var jwtToken = await jwtTokenService.GenerateToken(verifyOtpRequest.PhoneNumber);
                return Results.Ok(new VerifyOtpResponse(jwtToken, "success"));
            }
            // OTP verification logic would go here

            return Results.Ok(new VerifyOtpResponse("", "success"));
        }

        private async Task<IResult> GenerateGuestTokenAsync(IJwtTokenService jwtTokenService)
        {
            var token = jwtTokenService.GenerateGuestToken();

            return Results.Ok(token);
        }
    }
}
