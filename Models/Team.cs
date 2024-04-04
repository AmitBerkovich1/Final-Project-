using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Team
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("Employee")]
        public int employeeId { get; set; }
        public Employee? employee { get; set; }
        [ForeignKey("Case")]
        public int caseId { get; set; }
        public Case? myCase { get; set; }
        public DateTime? date { get; set; }
    }
}
