using AutoMapper;
using StudentManagement.Application.DTOs;
using StudentManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StudentManagement.Application.DTOs.FamilyDto;

namespace StudentManagement.Application.Mappers
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {

            CreateMap<MstStudents, StudentResponseDto>()
            .AfterMap((r, b) => b.ID = r.StudentAID)
            .ForMember(d => d.dateOfBirth, opt => opt.MapFrom(s => s.DOB.HasValue ? DateTime.Parse(s.DOB.ToString()).ToString("yyyy-MM-dd") : ""));


            CreateMap<StudentRequestDto, MstStudents>()
         .AfterMap((r, b) => b.DOB = r.DateOfBirth);
            CreateMap<StudentUpdateRequestDto, MstStudents>()
                .AfterMap((r, b) => b.DOB = r.dateOfBirth)
                   .AfterMap((r, b) => b.StudentAID = r.ID);


            CreateMap<MstStudents, StudentNationalityUpdateResponseDto>()
          .AfterMap((r, b) => b.ID = r.StudentAID);


            CreateMap<ViewStudentRelatives, FamilyMemberNationResponseDto>();

            CreateMap<ViewStudentRelatives, FamilyMemberResponseDto>()
  .AfterMap((r, b) => b.ID = r.MemberAID);
            
        }
    }
    public static class StudentMappers
    {
        static StudentMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<StudentProfile>())
               .CreateMapper();
        }
        internal static IMapper Mapper { get; }




        public static IEnumerable<StudentResponseDto> To_Model(this List<MstStudents> dto)
        {
            return Mapper.Map<IEnumerable<StudentResponseDto>>(dto);
        }

        public static MstStudents ToEntity(this StudentRequestDto dto)
        {
            return Mapper.Map<MstStudents>(dto);
        }
        public static MstStudents ToEntity(this StudentUpdateRequestDto dto)
        {
            return Mapper.Map<MstStudents>(dto);
        }
        public static StudentResponseDto ToModel(this MstStudents dto)
        {
            return Mapper.Map<StudentResponseDto>(dto);
        }

        public static StudentNationalityUpdateResponseDto To_Model(this MstStudents dto)
        {
            return Mapper.Map<StudentNationalityUpdateResponseDto>(dto);
        }


        public static IEnumerable<FamilyMemberResponseDto> ToModel(this List<ViewStudentRelatives> dto)
        {
            return Mapper.Map<IEnumerable<FamilyMemberResponseDto>>(dto);
        }
    }
}
