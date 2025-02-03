using Microsoft.EntityFrameworkCore;
using StudentManagement.Domain.Interfaces;
using StudentManagement.Domain.Models;

namespace StudentManagement.Persistance.Repositories
{

    public class MasterRepository : IMasterRepository
    {
        #region Private Variables
        private readonly StudentManagementDbContext _studentDbContext;
        #endregion

        #region Constructor
        public MasterRepository(StudentManagementDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }
        #endregion

        #region GET
        public async Task<List<MstNationalities>> GetAllNationalitiesAsync()
        {
            return await _studentDbContext?.MstNationalities?.ToListAsync();
        }
        #endregion
    }
}
