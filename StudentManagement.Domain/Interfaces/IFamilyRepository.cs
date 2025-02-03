using StudentManagement.Domain.Models;


namespace StudentManagement.Domain.Interfaces
{
    public interface IFamilyRepository
    {

        #region PUT
        Task<FamilyMember> UpdateFamilyMemberAsync(int id, FamilyMember updatedFamilyMember);
        Task<FamilyMember> UpdateFamilyMemberNationalityAsync(int familyMemberId, int nationalityId);
        #endregion

        #region DELETE
        Task<bool> DeleteFamilyMemberAsync(int id);
        #endregion

        #region GET
        Task<FamilyMember> GetFamilyMemberWithNationalityAsync(int familyMemberId);
        #endregion

    }
}
