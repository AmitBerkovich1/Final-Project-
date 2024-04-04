using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Case : IComparer<Case>
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("Company")]
        public int companyId { get; set; }
        public Company? company { get; set; }
        [ForeignKey("DangerLevel")]
        public int levelId { get; set; }
        public DangerLevel? level { get; set; }
        public DateTime? requiredDate { get; set; }
        public int? assedHours { get; set; }
        public int Compare(Case? x, Case? y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return 1;
            if (y == null) return -1;
            DateTime date = DateTime.Now;
            double xDistance = (x.requiredDate - date).Value.TotalDays;
            double yDistance = (y.requiredDate - date).Value.TotalDays;

            return (int)(yDistance - xDistance);
        }
    }
}
