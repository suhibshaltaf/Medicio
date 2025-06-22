namespace Medicio.PL.Areas.Dashboard.ViewModels.FeaturesVIMO
{
    public class FeaturesDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public string Icon { get; set; }

        public DateTime CreatedAT { get; set; }
    }
}
