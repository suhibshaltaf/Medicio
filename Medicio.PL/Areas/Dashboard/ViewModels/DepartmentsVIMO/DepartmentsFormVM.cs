namespace Medicio.PL.Areas.Dashboard.ViewModels.DepartmentsVIMO
{
    public class DepartmentsFormVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string line { get; set; }
        public string Description { get; set; }
        public string Tabs { get; set; }

        public IFormFile Image { get; set; }
        public string? ImageName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
