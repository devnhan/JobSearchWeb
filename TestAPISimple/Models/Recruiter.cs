using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestAPISimple.Models
{
    public class Recruiter
    {
        public long RecruiterID { get; set; }

        [StringLength(255)]
        public string RecruiterName { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(10)]
        public string PhoneNumber { get; set; }

        [StringLength(1000)]
        public string Image { get; set; }

        public string RecruiterEmail { get; set; }

        public string RecruiterPassword { get; set; }

        public bool? IsValid { get; set; }

        [StringLength(255)]
        public string Role { get; set; }
    }
}