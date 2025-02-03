using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Application.DTOs
{
    public class StudentRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
    public class StudentUpdateRequestDto
    {
        public int ID { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public DateTime? dateOfBirth { get; set; }
    }



    public class StudentResponseDto
    {
        public int ID { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? dateOfBirth { get; set; }
    }

    public class StudentNationalityUpdateResponseDto
    {
        public int ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int NationalityId { get; set; }
    }

    public class FamilyMemberNationResponseDto
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? RelationshipId { get; set; }
        public int? NationalityId { get; set; }
    }


}
