using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Company
    {
        [Key]
        public int id { get; set; }
        public string? name { get; set; }
        public string? headquarters { get; set; }
        [ForeignKey("LineOfBusiness")]
        public int businessId { get; set; }
        public LineOfBusiness? lineOfBusiness { get; set; }
    }
}
