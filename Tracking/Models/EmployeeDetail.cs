using System;
using System.Collections.Generic;

namespace Tracking.Models;

public partial class EmployeeDetail
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public int? RecordNo { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
