using StudentManagement.Domain.Models.Masters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Domain.Models
{
    public class MstStudents
    {
        [Key]
        public int StudentAID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DOB { get; set; }
        public int? NationalityID { get; set; }
    }
    public class ViewStudents
    {
        [Key]
        public int StudentAID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly? DOB { get; set; }
        public int? NationalityID { get; set; }
        public string? Nationality { get; set; }
    }
    public class ViewStudentRelatives
    {
        [Key]
        public int MemberAID { get; set; }
        public string? MemberFirstName { get; set; }
        public string? MemberLastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? RelativeRelationID { get; set; }
        public string? Relation { get; set; }
        public int? RelativeNationalityID { get; set; }
        public string? RelativeNationality { get; set; }
        public int StudentID { get; set; }
    }
}
