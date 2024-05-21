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
        [Required]
        public int hoursAssigned { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Employee other = (Employee)obj;
            return id == other.id &&
                   firstName == other.firstName &&
                   lastName == other.lastName &&
                   roleId == other.roleId &&
                   hoursAssigned == other.hoursAssigned &&
                   ((role == null && other.role == null) || (role != null && role.Equals(other.role)));
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + id.GetHashCode();
                hash = hash * 23 + (firstName?.GetHashCode() ?? 0);
                hash = hash * 23 + (lastName?.GetHashCode() ?? 0);
                hash = hash * 23 + roleId.GetHashCode();
                hash = hash * 23 + (role?.GetHashCode() ?? 0);
                hash = hash * 23 + hoursAssigned.GetHashCode();
                return hash;
            }
        }
    }
}
