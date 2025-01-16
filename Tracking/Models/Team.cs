using System;
using System.Collections.Generic;

namespace Tracking.Models;

public partial class Team
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<EmployeeTeam> EmployeeTeams { get; set; } = new List<EmployeeTeam>();
}
