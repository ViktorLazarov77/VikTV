using System;
using System.Collections.Generic;

namespace VikTV.Data.Models;

public partial class WatchHistory
{
    public int HistoryId { get; set; }

    public int ProfileId { get; set; }

    public int TitleId { get; set; }

    public DateTime? LastWatchedAt { get; set; }

    public int? ProgressMinutes { get; set; }

    public virtual Profile Profile { get; set; } = null!;

    public virtual Title Title { get; set; } = null!;
}
