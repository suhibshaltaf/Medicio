namespace Medicio.PL.Areas.Dashboard.ViewModels.TestimonialsVIMO
{
    public class TestimonialsDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string Job { set; get; }
        public string ImageName { get; set; }
        public DateTime CreatedAT { get; set; }

        public bool IsDeleted { get; set; }
    }
}
