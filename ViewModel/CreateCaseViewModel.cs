using FinalProject.Models;

namespace FinalProject.ViewModel
{
    public class CreateCaseViewModel
    {
        public int companyId { get; set; }
        public int dangerId { get; set; }
        public DateTime? reqiredDate { get; set; }
        public int? assedHours { get; set; }
        public IEnumerable<Company>? companies { get; set; }
        public IEnumerable<DangerLevel>? dangerLevels { get; set; }
    }
}
