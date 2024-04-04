using FinalProject.Models;

namespace FinalProject.ViewModel
{
    public class CreateEmployeeViewModel
    {
        public string? firstName {  get; set; }
        public string lastName { get; set; }
        public int roleId { get; set; }
        public int? salary { get; set; }
        public int hoursAssigned { get; set; }
        public IEnumerable<Role>? roles { get; set; }

    }
}
