using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestAPISimple.Models
{
    public class Candidates
    {
        [Key]
        public long CandidatesID { get; set; }

        [StringLength(255)]
        public string CandidatesEmail { get; set; }

        [StringLength(255)]
        public string CandidatesName { get; set; }

        public string CandidatesPassword { get; set; }

        public bool? IsValid { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(10)]
        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        [StringLength(500)]
        public string Image { get; set; }

        [StringLength(255)]
        public string Role { get; set; }
        public virtual CurriculumVitae CurriculumVitae { get; set; }
    }
}