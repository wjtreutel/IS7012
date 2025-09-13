using System.ComponentModel.DataAnnotations;

namespace RecruitCatTreutewm.Models
{
    public class JobTitle
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int MinimumSalary { get; set; }
        public int MaximumSalary { get; set; }
        public string Description { get; set; }
        public decimal RequiredYOE { get; set; 
        }
    }
}
