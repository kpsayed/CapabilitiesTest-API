using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StudentManagement.Domain.Interfaces;
using StudentManagement.Domain.Models;

namespace StudentManagement.Persistance.Repositories
{
    public class FamilyRepository : IFamilyRepository
    {
        #region private variables
        private readonly StudentManagementDbContext _studentDbContext;
        private static IConfiguration _config;
        #endregion

        #region constructor
        public FamilyRepository(IConfiguration config, StudentManagementDbContext studentDbContext)
        {
            _config = config;
            _studentDbContext = studentDbContext;
        }
        #endregion



        #region PUT
        public async Task<FamilyMember> UpdateFamilyMemberAsync(int id, FamilyMember updatedFamilyMember)
        {
            var existingFamilyMember = await _studentDbContext.FamilyMember.FindAsync(id);

            if (existingFamilyMember == null)
                return null;

            existingFamilyMember.MemberFirstName = updatedFamilyMember.MemberFirstName;
            existingFamilyMember.MemberLastName = updatedFamilyMember.MemberLastName;
            existingFamilyMember.DateOfBirth = updatedFamilyMember.DateOfBirth;
            existingFamilyMember.RelationshipID = updatedFamilyMember.RelationshipID;
            _studentDbContext.FamilyMember.Update(existingFamilyMember);
            await _studentDbContext.SaveChangesAsync();
            return existingFamilyMember;
        }
        public async Task<FamilyMember> UpdateFamilyMemberNationalityAsync(int familyMemberId, int nationalityId)
        {
            var objRelatives = new FamilyMember();
            try
            {
                var familyMember = await _studentDbContext.FamilyMember.FindAsync(familyMemberId);
                if (familyMember != null)
                {
                    familyMember.NationalityID = nationalityId;
                    await _studentDbContext.SaveChangesAsync();
                    objRelatives = await _studentDbContext.FamilyMember.FindAsync(familyMemberId);
                }
            }
            catch (Exception)
            {
            }
            return objRelatives;
        }
        #endregion

        #region DELETE
        public async Task<bool> DeleteFamilyMemberAsync(int id)
        {
            bool _status = false;
            try
            {
                var familyMember = await _studentDbContext.FamilyMember.FindAsync(id);

                if (familyMember == null)
                    return false;

                _studentDbContext.FamilyMember.Remove(familyMember);
                await _studentDbContext.SaveChangesAsync();

                _status = true;
            }
            catch (Exception)
            {

            }
            return _status;
        }
        #endregion

        #region GET
        public async Task<FamilyMember> GetFamilyMemberWithNationalityAsync(int familyMemberId)
        {
            var _familyMember = new FamilyMember();
            try
            {
                _familyMember = await _studentDbContext.FamilyMember.Where(fm => fm.MemberAID == familyMemberId).FirstOrDefaultAsync();
            }
            catch (Exception)
            {

            }
            return _familyMember;
        }
        #endregion
    }
}
