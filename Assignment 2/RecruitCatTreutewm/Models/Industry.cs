using System.ComponentModel.DataAnnotations;

namespace RecruitCatTreutewm.Models
{
    public class Industry
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(32)]
        public string Name { get; set; }
    }
}
