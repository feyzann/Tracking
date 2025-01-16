namespace Tracking.ViewModels
{
    public class CreateSupportViewModel
    {
        public string? CustomerFullName { get; set; }
        public string? Subject { get; set; }
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
        public string? Status { get; set; }

        public string? Note { get; set;}
    }
}
