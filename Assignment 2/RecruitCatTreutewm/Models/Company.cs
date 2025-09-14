using Microsoft.Extensions.Options;
using System;
using System.ComponentModel.DataAnnotations;

namespace RecruitCatTreutewm.Models
{
    public class Company
    {
        [Key]
        public int ID {  get; set; }
        public string Name {  get; set; }
        public int OpenPositionID { get; set; }
        public int MinimumSalary { get; set; }
        public int MaximumSalary { get; set; }
        public string Location { get; set; }
        public Nullable<DateTime> StartDate { get; set; }
        public int IndustryID  { get; set; }
        public Nullable<DateTime> PositionOpenDate { get; set; }
        public int RejectedCandidateCount { get; set; }
    }
}
