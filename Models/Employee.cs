using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Employee
    {
        [Key]
        public int id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        [ForeignKey("Role")]
        public int roleId { get; set; }
        public Role? role { get; set; }
        public int? salary { get; set; }
        [Required]
        public int hoursAssigned { get; set; }
    }
}
