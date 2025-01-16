namespace Tracking.Models
{
    public class SupportWithTimeDifference
    {
        public int Id { get; set; }

        public int? EmployeeId { get; set; }

        public string? CustomerFullName { get; set; }

        public string? Subject { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? Status { get; set; }

        public int Time { get; set; }
    }
}
