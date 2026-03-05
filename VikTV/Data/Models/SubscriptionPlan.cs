using System;
using System.Collections.Generic;

namespace VikTV.Data.Models;

public partial class SubscriptionPlan
{
    public int PlanId { get; set; }

    public string PlanName { get; set; } = null!;

    public decimal Price { get; set; }

    public string? MaxResolution { get; set; }

    public int? MaxScreens { get; set; }

    public virtual ICollection<UserSubscribtion> UserSubscribtions { get; set; } = new List<UserSubscribtion>();
}
