using StudentManagement.Domain.Models;

namespace StudentManagement.Domain.Interfaces
{
    public interface IMasterRepository
    {
        #region GET
        Task<List<MstNationalities>> GetAllNationalitiesAsync();
        #endregion
    }
}
