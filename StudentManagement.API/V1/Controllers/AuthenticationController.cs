using Microsoft.AspNetCore.Mvc;
using StudentManagement.Application.DTOs;
using StudentManagement.Application.Services.Interfaces;

namespace StudentManagement.API.V1.Controllers
{
    [ApiController]
    [Route("v{version:apiVersion}/api/[controller]")]
    [ApiVersion("1.0")]
    public class AuthenticationController : ControllerBase
    {
        #region private declares
        private readonly IAuthServices _authServices;
        #endregion

        #region constructor
        public AuthenticationController(IAuthServices authServices)
        {
            _authServices = authServices;
        }
        #endregion

        #region Authentication
        [HttpPost("get-token")]
        public IActionResult GetToken([FromBody] RoleRequest request)
        {
            if (request.Role != "Admin" && request.Role != "Registrar")
                return BadRequest("Invalid role selected");

            var token = _authServices.GenerateJwtToken(request);
            return Ok(new { token });
        }
        #endregion

    }
    

}
