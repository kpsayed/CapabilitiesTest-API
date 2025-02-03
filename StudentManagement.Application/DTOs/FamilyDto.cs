
namespace StudentManagement.Application.DTOs
{
    public class FamilyDto
    {

        #region Requests
        public class FamilyMemberRequestDto
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime DateOfBirth { get; set; }
            public int RelationshipId { get; set; }
        }

        #endregion

        #region Responses
        public class FamilyMemberResponseDto 
        {
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime? DateOfBirth { get; set; }
            public int? RelationshipId { get; set; }
        }
        public class MemberNationalityResponseDto
        {
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime? DateOfBirth { get; set; }
            public int? RelationshipId { get; set; }
            public int? NationalityId { get; set; }
        }
        #endregion
    }
}
