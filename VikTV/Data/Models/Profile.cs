using System;
using System.Collections.Generic;

namespace VikTV.Data.Models;

public partial class Profile
{
    public int ProfileId { get; set; }

    public int UserId { get; set; }

    public string ProfileName { get; set; } = null!;

    public bool? IsKids { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<WatchHistory> WatchHistories { get; set; } = new List<WatchHistory>();
}
