using System;
using System.Collections.Generic;

namespace VikTV.Data.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime? RegistrationDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Profile> Profiles { get; set; } = new List<Profile>();

    public virtual ICollection<UserSubscribtion> UserSubscribtions { get; set; } = new List<UserSubscribtion>();
}
