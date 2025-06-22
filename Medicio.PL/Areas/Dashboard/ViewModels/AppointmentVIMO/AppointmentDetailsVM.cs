namespace Medicio.PL.Areas.Dashboard.ViewModels.AppointmentVIMO
{
    public class AppointmentDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Message { get; set; }
        public string DoctorName { get; set; }
        public string DepartmentTitle { get; set; }
        public bool IsDeleted { get; set; } 
    }
}
