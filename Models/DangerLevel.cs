using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class DangerLevel
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int level { get; set; }
        public string? description { get; set; }
        public string? title { get; set; }
    }
}
