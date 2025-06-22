namespace Medicio.PL.Areas.Dashboard.ViewModels.DepartmentsVIMO
{
    public class DepartmentsDetailsVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string line { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public string ImageName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
