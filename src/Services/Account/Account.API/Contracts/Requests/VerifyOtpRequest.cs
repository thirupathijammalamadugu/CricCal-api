namespace Account.API.Contracts.Requests
{
    public record VerifyOtpRequest(string PhoneNumber, string Otp, string Purpose);
}