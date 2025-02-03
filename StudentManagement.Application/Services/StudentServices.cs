using Microsoft.AspNetCore.Mvc;
using StudentManagement.Application.DTOs;
using StudentManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using StudentManagement.Application.Mappers;
using StudentManagement.Domain.Models;
using Microsoft.AspNetCore.Http;
using StudentManagement.Application.Services.Interfaces;
using static StudentManagement.Application.DTOs.FamilyDto;

namespace StudentManagement.Application.Services
{
    public class StudentServices: IStudentServices
    {
        #region private variables
        public readonly IStudentRepository _studentRepository;
        #endregion
        #region constructor
        public StudentServices(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        #endregion

        #region Get all Students
        public async Task<IEnumerable<StudentResponseDto>> GetAllStudentsAsync()
        {
            var lstStudents = await _studentRepository.GetAllStudentsAsync();
            var dtoList = lstStudents.To_Model();
            return dtoList;
        }
        #endregion


        #region Add a new Student with Basic Details Only
        public async Task<StudentResponseDto> AddStudentAsync( StudentRequestDto request)
        {
            var srcStudent = request.ToEntity();
            var createdStudent = await _studentRepository.AddStudentAsync(srcStudent);
            var dto = createdStudent.ToModel();
            return dto;
        }

        #endregion


        #region Updates a Student’s Basic Details only
        public async Task<StudentResponseDto> UpdateStudentAsync(int id, StudentUpdateRequestDto model)
        {
            var src = model.ToEntity();
            var updatedStudent = await _studentRepository.UpdateStudentAsync(src);
            var dto = updatedStudent.ToModel();
            return dto;
        }
        #endregion



        #region Gets the Nationality of a particular student
        public async Task<StudentNationalityUpdateResponseDto> GetStudentByIdAsync(int id)
        {
            var src = await _studentRepository.GetStudentByIdAsync(id);
            var dto = src.To_Model();
            return dto;
        }
        #endregion

        #region Updates a Student’s Nationality
        public async Task<StudentNationalityUpdateResponseDto> UpdateStudentNationalityAsync(int id, int nationalityId)
        {
            var updatedStudent = await _studentRepository.UpdateStudentNationalityAsync(id, nationalityId);
            var dto = updatedStudent.To_Model();
            return dto;
        }
        #endregion

        #region Gets Family Members for a particular Student
        public async Task<IEnumerable<FamilyMemberResponseDto>> GetRelativesByStudentIdAsync(int id)
        {
            var familyMembers = await _studentRepository.GetRelativesByStudentIdAsync(id);
            var familyMembersDto = familyMembers.ToModel();
            return familyMembersDto;
        }
        #endregion

        #region Creates a new Family Member for a particular Student (without the nationality)
        public async Task<FamilyMemberResponseDto> AddFamilyMemberAsync(int id, FamilyMemberRequestDto request)
        {
            var src = request.ToEntity();
            var Response = await _studentRepository.AddFamilyMemberAsync(id, src);
            var ResponseDto = Response.ToModel();
            return ResponseDto;
        }
        #endregion

    }
}
