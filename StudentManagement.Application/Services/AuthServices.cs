using StudentManagement.Application.DTOs;
using StudentManagement.Application.Services.Interfaces;
using StudentManagement.Domain.Interfaces;

namespace StudentManagement.Application.Services
{
    public class AuthServices: IAuthServices
    {
        #region private variables
        public readonly IAuthRepository _authRepository;
        #endregion

        #region constructor
        public AuthServices(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        #endregion

        #region Methods
        public async Task<string> GenerateJwtToken(RoleRequest request)
        {
            var token =  _authRepository.GenerateJwtToken(request.Role);
            return token;
        }
        #endregion
    }
}
