using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestAPISimple.Models
{
    public class CurriculumVitae
    {
        public long CurriculumVitaeID { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string ApplicantPosition { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(10)]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string Gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(255)]
        public string City { get; set; }

        public string SpecificAddress { get; set; }

        [StringLength(255)]
        public string JobSeekingNeeds { get; set; }

        public double? MinimumDesiredSalary { get; set; }

        public string IntroduceYourself { get; set; }

        public int? WorkExperienceID { get; set; }

        [StringLength(255)]
        public string Education { get; set; }

        //public int? SkillID { get; set; }

        public long? CandidatesID { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<ApplicationDetail> ApplicationDetails { get; set; }

        public virtual Candidates Candidate { get; set; }

        //public virtual Skill Skill { get; set; }

        //public virtual WorkExperience WorkExperience { get; set; }
    }
}