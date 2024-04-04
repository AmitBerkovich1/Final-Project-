using FinalProject.Models;

namespace FinalProject.ViewModel
{
    public class CreateCompanyViewModel
    {
        public string? name { get; set; }
        public string? headquarters { get; set; }
        public int businessId { get; set; }
        public IEnumerable<LineOfBusiness>? lines { get; set; }
    }
}
