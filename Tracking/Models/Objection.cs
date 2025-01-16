using System;
using System.Collections.Generic;

namespace Tracking.Models;

public partial class Objection
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public DateTime? Date { get; set; }

    public string? Response { get; set; }

    public string? Status { get; set; }

    public int? BonusId { get; set; }

    public virtual Bonu? Bonus { get; set; }
}
