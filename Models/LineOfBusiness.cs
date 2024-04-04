using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class LineOfBusiness
    {
        [Key]
        public int id { get; set; }
        public string? title { get; set; }
    }
}
