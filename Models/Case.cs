using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Case : IComparable<Case>
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
        public int CompareTo(Case? other)
        {
            if (other == null)
            {
                // If other is null, this instance is greater.
                return 1;
            }

            if (requiredDate.HasValue && other.requiredDate.HasValue)
            {
                // Compare based on the absolute difference between required dates and the current date.
                TimeSpan diffThis = requiredDate.Value - DateTime.Now;
                TimeSpan diffOther = other.requiredDate.Value - DateTime.Now;

                return diffThis.CompareTo(diffOther);
            }
            else if (requiredDate.HasValue)
            {
                // If other has no required date but this instance has, this instance is greater.
                return -1;
            }
            else if (other.requiredDate.HasValue)
            {
                // If this instance has no required date but other has, other is greater.
                return 1;
            }
            else
            {
                // If neither has a required date, consider them equal.
                return 0;
            }
        }
    }
}
