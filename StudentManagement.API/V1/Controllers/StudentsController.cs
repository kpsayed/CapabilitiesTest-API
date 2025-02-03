using Microsoft.AspNetCore.Mvc;
using StudentManagement.Application.Services.Interfaces;
using StudentManagement.Application.DTOs;
using static StudentManagement.Application.DTOs.FamilyDto;

namespace StudentManagement.API.V1.Controllers
{
    [ApiController]
    [Route("v{version:apiVersion}/api/[controller]")]
    [ApiVersion("1.0")]
    public class StudentsController : ControllerBase
    {
        #region private declares
        private readonly IStudentServices _studentServices;
        #endregion

        #region constructor
        public StudentsController(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }
        #endregion

        #region Get all Students
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var lstStudents = await _studentServices.GetAllStudentsAsync();
            return Ok(lstStudents);
        }
        #endregion

        #region Add a new Student with Basic Details Only
        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] StudentRequestDto studentDto)
        {
            if (ModelState.IsValid)
            {
                var createdStudent = await _studentServices.AddStudentAsync(studentDto);
                return Ok(createdStudent);
            }
            else
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        }

        #endregion

        #region Updates a Student’s Basic Details only
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] StudentUpdateRequestDto model)
        {
            if (id != model.ID)
                return BadRequest("ID in the URL and request body must match.");
            var updatedStudent = await _studentServices.UpdateStudentAsync(id,model);

            if (updatedStudent == null)
                return NotFound($"Student with ID {id} not found.");

            return Ok(updatedStudent);
        }
        #endregion

        #region Gets the Nationality of a particular student
        [HttpGet("{id}/Nationality")]
        public async Task<ActionResult<StudentNationalityUpdateResponseDto>> GetStudentByIdAsync(int id)
        {
            var dto = await _studentServices.GetStudentByIdAsync(id);
            return Ok(dto);
        }
        #endregion

        #region Updates a Student’s Nationality
        [HttpPut("{id}/Nationality/{nationalityId}")]
        public async Task<ActionResult<StudentNationalityUpdateResponseDto>> UpdateStudentNationality(int id, int nationalityId)
        {
            var updatedStudent = await _studentServices.UpdateStudentNationalityAsync(id, nationalityId);

            if (updatedStudent == null)
                return NotFound($"Student with ID {id} not found.");
            return Ok(updatedStudent);
        }
        #endregion

        #region Gets Family Members for a particular Student
        [HttpGet("{id}/FamilyMembers")]
        public async Task<IActionResult> GetFamilyMembers(int id)
        {
            var familyMembers = await _studentServices.GetRelativesByStudentIdAsync(id);

            if (familyMembers == null || !familyMembers.Any())
                return NotFound($"No family members found for Student ID {id}.");
            return Ok(familyMembers);
        }
        #endregion

        #region Creates a new Family Member for a particular Student (without the nationality)
        [HttpPost("{id}/FamilyMembers")]
        public async Task<IActionResult> AddFamilyMember(int id, [FromBody] FamilyMemberRequestDto request)
        {
            if (request == null)
                return BadRequest("Invalid request data.");
            var ResponseDto = await _studentServices.AddFamilyMemberAsync(id, request);
            return Ok(ResponseDto);
        }
        #endregion
    }
}
