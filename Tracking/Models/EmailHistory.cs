using System;
using System.Collections.Generic;

namespace Tracking.Models;

public partial class EmailHistory
{
    public int Id { get; set; }

    public string? Subject { get; set; }

    public string? Description { get; set; }

    public int? EmployeeId { get; set; }

    public bool? IsRead { get; set; }

    public virtual Employee? Employee { get; set; }
}
