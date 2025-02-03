using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Application.Services.Interfaces;

namespace StudentManagement.API.V1.Controllers
{
    [ApiController]
    [Route("v{version:apiVersion}/api/[controller]")]
    [ApiVersion("1.0")]
    public class NationalitiesController : ControllerBase
    {
        #region Private Declares
        private readonly IMastersServices _nationalityServices;
        #endregion

        #region Constructor
        public NationalitiesController(IMastersServices nationalityServices)
        {
            _nationalityServices = nationalityServices;
        }
        #endregion

        #region Gets all nationalities in the system
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllNationalities()
        {
            try
            {
                var lstNationalities = await _nationalityServices.GetAllNationalities();
                if (lstNationalities == null || lstNationalities.Count() == 0)
                    return NotFound("No nationalities found.");
                return Ok(lstNationalities);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }
        #endregion
    }
}
