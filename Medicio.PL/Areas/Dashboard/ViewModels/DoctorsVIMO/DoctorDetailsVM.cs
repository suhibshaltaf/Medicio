namespace Medicio.PL.Areas.Dashboard.ViewModels.DoctorsVIMO
{
    public class DoctorDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public string DepartmentName { get; set; }
        public string ImageName { get; set; }

        public DateTime CreatedAT { get; set; }
    }
}
