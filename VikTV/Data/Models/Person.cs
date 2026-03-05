using System;
using System.Collections.Generic;

namespace VikTV.Data.Models;

public partial class Person
{
    public int PersonId { get; set; }

    public string FullName { get; set; } = null!;

    public DateOnly? BirthDate { get; set; }

    public virtual ICollection<TitleCredit> TitleCredits { get; set; } = new List<TitleCredit>();
}
