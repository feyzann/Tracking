using System;
using System.Collections.Generic;

namespace Tracking.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public int? EmployeeDetailId { get; set; }

    public int? RoleId { get; set; }

    public virtual ICollection<Bonu> Bonus { get; set; } = new List<Bonu>();

    public virtual ICollection<EmailHistory> EmailHistories { get; set; } = new List<EmailHistory>();

    public virtual EmployeeDetail? EmployeeDetail { get; set; }

    public virtual ICollection<EmployeeTeam> EmployeeTeams { get; set; } = new List<EmployeeTeam>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<Support> Supports { get; set; } = new List<Support>();
}
