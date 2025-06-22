namespace Medicio.DAL.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Message { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime AppointmentTime { get; set; } // الوقت المحدد للحجز

        // Navigation properties
        public virtual Doctors Doctor { get; set; }
        public virtual Departments Department { get; set; }
    }
}
