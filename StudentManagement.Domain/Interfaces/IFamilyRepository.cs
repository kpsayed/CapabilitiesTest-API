using StudentManagement.Domain.Models;


namespace StudentManagement.Domain.Interfaces
{
    public interface IFamilyRepository
    {

        #region Put Methods
        Task<FamilyMember> UpdateFamilyMemberAsync(int id, FamilyMember updatedFamilyMember);
        Task<FamilyMember> UpdateFamilyMemberNationalityAsync(int familyMemberId, int nationalityId);
        #endregion

        #region Delete Methods
        Task<bool> DeleteFamilyMemberAsync(int id);
        #endregion

        #region Get Methods
        Task<FamilyMember> GetFamilyMemberWithNationalityAsync(int familyMemberId);
        #endregion

    }
}
