using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RecruitCatTreutewm.Models
{
    public class JobTitle
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(32)] // Someone in the real world probably has a 500+ character job title, but they will not have it here.
        public string Name { get; set; }

        [Required]
        [StringLength(512)]
        public string Description { get; set; }


        [Required]
        [DisplayName("Min Salary")]
        [Range(0,int.MaxValue)]
        public int MinimumSalary { get; set; }

        [Required]
        [DisplayName("Max Salary")]
        [Range(0,int.MaxValue)]
        public int MaximumSalary { get; set; }


        [DisplayName("Min YOE")]
        [Range(0,100)]
        public Nullable<double> RequiredYOE { get; set; 
        }
    }
}
