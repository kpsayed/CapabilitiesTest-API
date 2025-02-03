using AutoMapper;
using StudentManagement.Domain.Models;
using static StudentManagement.Application.DTOs.FamilyDto;

namespace StudentManagement.Application.Mappers
{
    public class FamilyProfile : Profile
    {
        public FamilyProfile()
        {
            #region Updates a particular Family Member
            CreateMap<FamilyMemberRequestDto, FamilyMember>()
                .AfterMap((r, b) => b.MemberFirstName = r.FirstName).AfterMap((r, b) => b.MemberLastName = r.LastName)
                .AfterMap((r, b) => b.IsDeleted = false);

            CreateMap<FamilyMember, FamilyMemberResponseDto>().AfterMap((r, b) => b.ID = r.MemberAID)
                .AfterMap((r, b) => b.RelationshipId = r.RelationshipID).AfterMap((r, b) => b.FirstName = r.MemberFirstName)
                .AfterMap((r, b) => b.LastName = r.MemberLastName);
            #endregion

            #region Gets a nationality associated with a family member
            CreateMap<FamilyMember, MemberNationalityResponseDto>().AfterMap((r, b) => b.ID = r.MemberAID)
                .AfterMap((r, b) => b.RelationshipId = r.RelationshipID).AfterMap((r, b) => b.FirstName = r.MemberFirstName)
                .AfterMap((r, b) => b.NationalityId = r.NationalityID).AfterMap((r, b) => b.LastName = r.MemberLastName);
            #endregion
        }
    }
    public static class FamilyMappers
    {
        static FamilyMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<FamilyProfile>())
               .CreateMapper();
        }
        internal static IMapper Mapper { get; }

        #region Updates a particular Family Member
        public static FamilyMember ToEntity(this FamilyMemberRequestDto dto)
        {
            return Mapper.Map<FamilyMember>(dto);
        }
        public static FamilyMemberResponseDto ToModel(this FamilyMember dto)
        {
            return Mapper.Map<FamilyMemberResponseDto>(dto);
        }

        #endregion

        #region Gets a nationality associated with a family member
        public static MemberNationalityResponseDto To_Model(this FamilyMember dto)
        {
            return Mapper.Map<MemberNationalityResponseDto>(dto);
        }
        #endregion
    }
}
