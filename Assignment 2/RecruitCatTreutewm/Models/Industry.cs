using System.ComponentModel.DataAnnotations;

namespace RecruitCatTreutewm.Models
{
    public class Industry
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
