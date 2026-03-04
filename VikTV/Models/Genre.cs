using System;
using System.Collections.Generic;

namespace VikTV.Models;

public partial class Genre
{
    public int GenreId { get; set; }

    public string GenreName { get; set; } = null!;

    public virtual ICollection<Title> Titles { get; set; } = new List<Title>();
}
