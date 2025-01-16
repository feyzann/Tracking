namespace Tracking.Models
{
    public class ObjectionsForTeamLead
    {
        public int? ObjectionId { get; set; }
        public string? Description { get; set; }
        public DateTime ObjectionDate { get; set; }
        public string? Response { get; set; }
        public string? Status { get; set; }
        public int? EmployeeId { get; set; }
        public string? EmployeeSurname { get; set; }
        public string? EmployeeName { get; set; }
        public int? TeamId { get; set; }
    }
}
