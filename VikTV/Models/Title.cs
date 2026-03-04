using System;
using System.Collections.Generic;

namespace VikTV.Models;

public partial class Title
{
    public int TitleId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int? ReleaseYear { get; set; }

    public string Type { get; set; } = null!;

    public string? MaturityRating { get; set; }

    public virtual Movie? Movie { get; set; }

    public virtual Show? Show { get; set; }

    public virtual ICollection<TitleCredit> TitleCredits { get; set; } = new List<TitleCredit>();

    public virtual ICollection<WatchHistory> WatchHistories { get; set; } = new List<WatchHistory>();

    public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();
}
