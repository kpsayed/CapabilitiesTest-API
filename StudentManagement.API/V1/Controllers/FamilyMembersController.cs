using Microsoft.AspNetCore.Mvc;
using static StudentManagement.Application.DTOs.FamilyDto;
using StudentManagement.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace StudentManagement.API.V1.Controllers
{
    [ApiController]
    [Route("v{version:apiVersion}/api/[controller]")]
    [ApiVersion("1.0")]
    public class FamilyMembersController : ControllerBase
    {
        #region private declares
        private readonly IFamilyServices _familyServices;
        #endregion

        #region constructor
        public FamilyMembersController(IFamilyServices familyServices)
        {
            _familyServices = familyServices;
        }
        #endregion


        #region Updates a particular Family Member
        [HttpPut("{id})")]
        [Authorize(Roles = "Registrar")]
        public async Task<IActionResult> UpdateFamilyMember(int id, [FromBody] FamilyMemberRequestDto request)
        {
            if (request == null)
                return BadRequest("Invalid request data.");

            var ResponseDto = await _familyServices.UpdateFamilyMemberAsync(id, request);
            if (ResponseDto == null)
                return NotFound("Family member not found.");
            return Ok(ResponseDto);
        }
        #endregion

        #region Deletes a family member for a particular Student
        [HttpDelete("{id}")]
        [Authorize(Roles = "Registrar")]
        public async Task<IActionResult> DeleteFamilyMember(int id)
        {
            var isDeleted = await _familyServices.DeleteFamilyMemberAsync(id);

            if (!isDeleted)
                return NotFound("Family member not found.");

            return NoContent();
        }
        #endregion

        #region Gets a nationality associated with a family member

        [HttpGet("{familyMemberId}/Nationality/{nationalityId}")]
        [Authorize]
        public async Task<IActionResult> GetFamilyMemberNationality(int familyMemberId, int nationalityId)
        {
            var familyMember = await _familyServices.GetFamilyMemberWithNationalityAsync(familyMemberId);

            if (familyMember == null || familyMember.NationalityId == nationalityId)
                return NotFound("Family member or nationality not found.");

            return Ok(familyMember);
        }

        #endregion

        #region Updates a particular Family Member’s Nationality
        [HttpPut("{familyMemberId}/Nationality/{nationalityId}")]
        [Authorize(Roles = "Registrar")]
        public async Task<IActionResult> UpdateFamilyMemberNationality(int familyMemberId, int nationalityId)
        {
            var ResponseDto = await _familyServices.UpdateFamilyMemberNationalityAsync(familyMemberId, nationalityId);

            if (ResponseDto == null)
                return NotFound("Family member not found or update failed.");
            return Ok(ResponseDto);
        }
        #endregion
    }
}
