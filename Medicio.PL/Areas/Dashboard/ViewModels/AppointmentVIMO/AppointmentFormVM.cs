using System.ComponentModel.DataAnnotations;

namespace Medicio.PL.Areas.Dashboard.ViewModels.AppointmentVIMO
{
    public class AppointmentFormVM
    {
        public int Id { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        public string Message { get; set; }
    }
}
