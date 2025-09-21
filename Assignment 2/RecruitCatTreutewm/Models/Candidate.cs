using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RecruitCatTreutewm.Models
{
    public class Candidate
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("First Name")]
        [StringLength(32)]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [StringLength(32)]
        public string LastName { get; set; }

        [DisplayName("Target Salary")]
        [Range(0, int.MaxValue)]
        public int TargetSalary { get; set; }

        [DisplayName("Start Date")]
        [DataType(DataType.Date)]
        public Nullable<DateTime> StartDate {  get; set; }

        public Nullable<int> CompanyID { get; set; }

        public int IndustryID { get; set; }

        public int JobTitleID { get; set; }


        [DisplayName("Employed?")] 
        public bool IsEmployed { get; set; }

        [DisplayName("Desperate?")] 
        public bool IsDesperate { get; set; }
    }
}
