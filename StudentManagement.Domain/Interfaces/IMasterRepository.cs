using StudentManagement.Domain.Models;

namespace StudentManagement.Domain.Interfaces
{
    public interface IMasterRepository
    {
        #region Get Methods
        Task<List<MstNationalities>> GetAllNationalitiesAsync();
        #endregion
    }
}
