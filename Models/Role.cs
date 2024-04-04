using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Role
    {
        [Key]
        public int id { get; set; }
        public string? title { get; set; }
        public string? jobDescription { get; set; }
        public int? maxHours { get; set; }
    }
}
