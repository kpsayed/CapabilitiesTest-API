using Microsoft.AspNetCore.Mvc;
using StudentManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StudentManagement.Application.DTOs.FamilyDto;

namespace StudentManagement.Application.Services.Interfaces
{
    public interface IStudentServices
    {
        Task<IEnumerable<StudentResponseDto>> GetAllStudentsAsync();
        Task<StudentResponseDto> AddStudentAsync(StudentRequestDto request);
        Task<StudentResponseDto> UpdateStudentAsync(int id, StudentUpdateRequestDto model);
        Task<StudentNationalityUpdateResponseDto> GetStudentByIdAsync(int id);
        Task<StudentNationalityUpdateResponseDto> UpdateStudentNationalityAsync(int id, int nationalityId);
        Task<IEnumerable<FamilyMemberResponseDto>> GetRelativesByStudentIdAsync(int id);
        Task<FamilyMemberResponseDto> AddFamilyMemberAsync(int id, FamilyMemberRequestDto request);
    }
}
