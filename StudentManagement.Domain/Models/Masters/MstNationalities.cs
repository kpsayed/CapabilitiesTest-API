using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Domain.Models
{
    public class MstNationalities
    {
        [Key]
        public int NationalityAID { get; set; }
        public string? Nationality { get; set; }
        public int? OrderIndex { get; set; }
        public bool? IsActive { get; set; }
    }
}
