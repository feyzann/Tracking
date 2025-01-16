using System;
using System.Collections.Generic;

namespace Tracking.Models;

public partial class Support
{
    public int Id { get; set; }

    public int? EmployeeId { get; set; }

    public string? CustomerFullName { get; set; }

    public string? Subject { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Status { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<SupportDetail> SupportDetails { get; set; } = new List<SupportDetail>();
}
