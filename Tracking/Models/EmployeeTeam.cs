using System;
using System.Collections.Generic;

namespace Tracking.Models;

public partial class EmployeeTeam
{
    public int Id { get; set; }

    public int? EmployeeId { get; set; }

    public int? TeamId { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Team? Team { get; set; }
}
