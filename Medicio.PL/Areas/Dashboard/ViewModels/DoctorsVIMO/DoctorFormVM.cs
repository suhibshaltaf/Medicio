using Microsoft.AspNetCore.Mvc.Rendering;

namespace Medicio.PL.Areas.Dashboard.ViewModels.DoctorsVIMO
{
    public class DoctorFormVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile Image { get; set; } 

        public string? ImageName { get; set; }
        public int? DepartmentId { get; set; }
        public string jop { get; set; }

        public SelectList? Departments { get; set; }
        public bool IsDeleted { get; set; }
    }
}
