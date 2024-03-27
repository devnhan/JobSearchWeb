using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestAPISimple.Models
{
    public class Recruitment
    {
        public long RecruitmentID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? JobPostingDay { get; set; }

        [StringLength(255)]
        public string Career { get; set; }

        [StringLength(255)]
        public string Skill { get; set; }

        [StringLength(255)]
        public string LanguageOfProfile { get; set; }

        [StringLength(255)]
        public string Formal { get; set; }

        public long? StaffID { get; set; }

        public long? RecruiterID { get; set; }

        public string Email { get; set; }

        public string CompanyName { get; set; }

        [StringLength(10)]
        public string PhoneNumber { get; set; }

        public string Description { get; set; }

        [StringLength(500)]
        public string Image { get; set; }

        public string Title { get; set; }

        public string Wage { get; set; }
    }
}