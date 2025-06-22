namespace Medicio.PL.Areas.Dashboard.ViewModels.PricingVIMO
{
    public class PricingDetailsVM
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; }

        public List<string> Features { get; set; }
    }
}
