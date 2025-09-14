using System.ComponentModel.DataAnnotations;

namespace RecruitCatTreutewm.Models
{
    public class Candidate
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TargetSalary { get; set; }
        public Nullable<DateTime> StartDate {  get; set; }
        public Nullable<int> CompanyID { get; set; }
        public int IndustryID { get; set; }
        public int JobTitleID { get; set; }
        public bool IsEmployed { get; set; }
        public bool IsDesperate { get; set; }
    }
}
