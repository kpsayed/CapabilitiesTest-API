﻿using AutoMapper;
using StudentManagement.Domain.Models;
using StudentManagement.Application.DTOs;

namespace StudentManagement.Application.Mappers
{
    public class MastersProfile : Profile
    {
        public MastersProfile()
        {
            #region Nationality
            CreateMap<MstNationalities, DropdownResponseDto>()
               .AfterMap((r, b) => b.ID = r.NationalityAID).AfterMap((r, b) => b.Name = r.Nationality);
            #endregion
        }
    }
    public static class NationalityMappers
    {
        static NationalityMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<MastersProfile>())
               .CreateMapper();
        }
        internal static IMapper Mapper { get; }

        #region Nationality
        public static IEnumerable<DropdownResponseDto> ToModel(this List<MstNationalities> dto)
        {
            return Mapper.Map<IEnumerable<DropdownResponseDto>>(dto);
        }
        #endregion
    }
}
