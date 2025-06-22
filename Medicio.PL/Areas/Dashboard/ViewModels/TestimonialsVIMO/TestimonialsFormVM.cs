namespace Medicio.PL.Areas.Dashboard.ViewModels.TestimonialsVIMO
{
    public class TestimonialsFormVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string Job { set; get; }
        public IFormFile Image { get; set; }
        public string? ImageName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
