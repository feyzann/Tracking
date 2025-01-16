using System;
using System.Collections.Generic;

namespace Tracking.Models;

public partial class Bonu
{
    public int Id { get; set; }

    public int? EmployeeId { get; set; }

    public decimal? Price { get; set; }

    public DateTime? Date { get; set; }

    public int? TotalSupport { get; set; }

    public int? TotalTime { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<Objection> Objections { get; set; } = new List<Objection>();
}
