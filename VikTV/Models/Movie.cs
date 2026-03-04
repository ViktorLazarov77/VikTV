using System;
using System.Collections.Generic;

namespace VikTV.Models;

public partial class Movie
{
    public int MovieId { get; set; }

    public int? DurationMinutes { get; set; }

    public string? VideoUrl { get; set; }

    public virtual Title MovieNavigation { get; set; } = null!;
}
