namespace Authentication.Core.Abstractions.Services
{
    public interface IVerificationService
    {
        public void VerifyPassword(string email, string hashedPassword, string password);
    }
}
