namespace landing.PL.Areas.Dashboard.ViewModels.ServicesVMA
{
    public class serviceDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public string ImageName { get; set; }

        public DateTime CreatedAT { get; set; }
    }
}
