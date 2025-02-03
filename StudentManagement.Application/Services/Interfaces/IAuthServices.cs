using StudentManagement.Application.DTOs;

namespace StudentManagement.Application.Services.Interfaces
{
    public interface IAuthServices
    {
        Task<string> GenerateJwtToken(RoleRequest request);
    }
}
