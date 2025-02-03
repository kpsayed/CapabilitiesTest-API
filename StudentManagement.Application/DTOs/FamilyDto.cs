using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Application.DTOs
{
    public class FamilyDto
    {

        #region Requests
        public class FamilyMemberRequestDto
        {
            //Updates a particular Family Member || Gets a nationality associated with a family member
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime DateOfBirth { get; set; }
            public int RelationshipId { get; set; }
        }

        #endregion

        #region Responses
        public class FamilyMemberResponseDto //Updates a particular Family Member 
        {
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime? DateOfBirth { get; set; }
            public int? RelationshipId { get; set; }
        }
        public class MemberNationalityResponseDto //Gets a nationality associated with a family member
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
