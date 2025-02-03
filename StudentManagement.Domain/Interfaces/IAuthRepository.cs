
namespace StudentManagement.Domain.Interfaces
{
    public interface IAuthRepository
    {
        string GenerateJwtToken(string role);
    }
}
