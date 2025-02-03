using StudentManagement.Domain.Interfaces;
using StudentManagement.Application.Mappers;
using StudentManagement.Application.DTOs;
using StudentManagement.Application.Services.Interfaces;

namespace StudentManagement.Application.Services
{
    public class MastersServices : IMastersServices
    {
        #region private variables
        public readonly IMasterRepository _masterRepository;
        #endregion

        #region constructor
        public MastersServices(IMasterRepository masterRepository)
        {
            _masterRepository = masterRepository;
        }
        #endregion

        #region Nationality
        public async Task<IEnumerable<DropdownResponseDto>> GetAllNationalities()
        {
            var lstNationalities = await _masterRepository.GetAllNationalitiesAsync();
            var dtoList = lstNationalities.ToModel();
            return dtoList;
        }
        #endregion
    }
}
