using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Domain.Models.Masters
{
    public class MstRelationships
    {
        [Key]
        public int RelationAID { get; set; }
        public string? Relation { get; set; }
        public int? OrderIndex { get; set; }
        public bool? IsActive { get; set; }
    }
}
