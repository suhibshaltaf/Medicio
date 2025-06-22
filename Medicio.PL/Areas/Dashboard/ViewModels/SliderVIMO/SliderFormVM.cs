namespace Medicio.PL.Areas.Dashboard.ViewModels.SliderVIMO
{
    public class SliderFormVM
    {

        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        public IFormFile Image { get; set; }

        public string? ImageName { get; set; }
        public bool Isdeleted { get; set; }
    }
}
