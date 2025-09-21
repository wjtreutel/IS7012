using Microsoft.Extensions.Options;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RecruitCatTreutewm.Models
{
    public class Company
    {
        [Key]
        public int ID {  get; set; }

        [Required]
        [StringLength(32)]
        public string Name {  get; set; }

        [Required]
        public int OpenPositionID { get; set; }

        [DisplayName("Min Salary")]
        [Range(0,int.MaxValue)]
        public int MinimumSalary { get; set; }

        [DisplayName("Max Salary>")]
        [Range(0, int.MaxValue)]
        public int MaximumSalary { get; set; }

        [Required]
        [StringLength(64)]
        public string Location { get; set; }

        [DisplayName("Start Date")]
        [DataType(DataType.Date)]
        public Nullable<DateTime> StartDate { get; set; }

        [Required]
        public int IndustryID  { get; set; }

        [DisplayName("Position Open Date")]
        [DataType(DataType.Date)]
        public Nullable<DateTime> PositionOpenDate { get; set; }

        [Required]
        [DisplayName("Rejected Candidates")]
        [Range(0,int.MaxValue)]
        public int RejectedCandidateCount { get; set; }
    }
}
