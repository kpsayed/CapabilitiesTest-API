using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StudentManagement.Application.DTOs.FamilyDto;

namespace StudentManagement.Application.Services.Interfaces
{
    public interface IFamilyServices
    {
        Task<FamilyMemberResponseDto> UpdateFamilyMemberAsync(int id, FamilyMemberRequestDto request);
        Task<bool> DeleteFamilyMemberAsync(int id);
        Task<MemberNationalityResponseDto> GetFamilyMemberWithNationalityAsync(int familyMemberId);
        Task<MemberNationalityResponseDto> UpdateFamilyMemberNationalityAsync(int familyMemberId, int nationalityId);
    }
}
