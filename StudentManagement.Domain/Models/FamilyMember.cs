using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Domain.Models
{
    public class FamilyMember
    {
        [Key]
        public int MemberAID { get; set; }
        public string? MemberFirstName { get; set; }
        public string? MemberLastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? RelationshipID { get; set; }
        public int? NationalityID { get; set; }
        public int? StudentID { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
