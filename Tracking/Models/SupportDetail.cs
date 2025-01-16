using System;
using System.Collections.Generic;

namespace Tracking.Models;

public partial class SupportDetail
{
    public int Id { get; set; }

    public int? SupportId { get; set; }

    public string? Message { get; set; }

    public virtual Support? Support { get; set; }
}
