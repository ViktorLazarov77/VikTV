using System;
using System.Collections.Generic;

namespace VikTV.Data.Models;

public partial class TitleCredit
{
    public int TitleId { get; set; }

    public int PersonId { get; set; }

    public string? Role { get; set; }

    public virtual Person Person { get; set; } = null!;

    public virtual Title Title { get; set; } = null!;
}
