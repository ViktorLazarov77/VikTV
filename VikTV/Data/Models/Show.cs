using System;
using System.Collections.Generic;

namespace VikTV.Data.Models;

public partial class Show
{
    public int ShowId { get; set; }

    public int? NumberOfSeasons { get; set; }

    public virtual Title ShowNavigation { get; set; } = null!;
}
