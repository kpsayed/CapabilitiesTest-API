using Microsoft.AspNetCore.Mvc;
using StudentManagement.Application.Services.Interfaces;
using StudentManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Application.Mappers;
using static StudentManagement.Application.DTOs.FamilyDto;

namespace StudentManagement.Application.Services
{
    public class FamilyServices : IFamilyServices
    {
        #region private variables
        public readonly IFamilyRepository _familyRepository;
        #endregion

        #region constructor
        public FamilyServices(IFamilyRepository familyRepository)
        {
            _familyRepository = familyRepository;
        }
        #endregion

        #region Updates a particular Family Member
        public async Task<FamilyMemberResponseDto> UpdateFamilyMemberAsync(int id, FamilyMemberRequestDto request)
        {
            var src = request.ToEntity();
            var updatedFamilyMember = await _familyRepository.UpdateFamilyMemberAsync(id, src);
            var ResponseDto = updatedFamilyMember.ToModel();
            return ResponseDto;
        }
        #endregion

        #region Deletes a family member for a particular Student
        public async Task<bool> DeleteFamilyMemberAsync(int id)
        {
            var isDeleted = await _familyRepository.DeleteFamilyMemberAsync(id);
            return isDeleted;
        }
        #endregion
        #region Gets a nationality associated with a family member

        #endregion
        #region Gets a nationality associated with a family membery
        public async Task<MemberNationalityResponseDto> GetFamilyMemberWithNationalityAsync(int familyMemberId)
        {
            var updatedFamilyMember = await _familyRepository.GetFamilyMemberWithNationalityAsync(familyMemberId);
            var ResponseDto = updatedFamilyMember.To_Model();
            return ResponseDto;
        }
        #endregion

        #region Updates a particular Family Member’s Nationality
        public async Task<MemberNationalityResponseDto> UpdateFamilyMemberNationalityAsync(int familyMemberId, int nationalityId)
        {
            var updatedFamilyMember = await _familyRepository.UpdateFamilyMemberNationalityAsync(familyMemberId, nationalityId);
            var ResponseDto = updatedFamilyMember.To_Model();
            return ResponseDto;
        }
        #endregion
    }
}
