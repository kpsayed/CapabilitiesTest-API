using StudentManagement.Application.DTOs;

namespace StudentManagement.Application.Services.Interfaces
{
    public interface IMastersServices
    {
        #region Nationality
        Task<IEnumerable<DropdownResponseDto>> GetAllNationalities();
        #endregion
    }
}
