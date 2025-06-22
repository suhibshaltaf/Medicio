namespace Medicio.PL.Areas.Dashboard.ViewModels.AppointmentVIMO
{
    public class AppointmentVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; } // يمكن استخدامه لتمثيل حالة الموعد
        public string TimeRemaining { get; set; } // وقت الانتظار
        public DateTime AppointmentDate { get; set; }

        public bool IsDeleted { get; set; }

    }
}
