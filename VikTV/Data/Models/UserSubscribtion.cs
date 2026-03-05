using System;
using System.Collections.Generic;

namespace VikTV.Data.Models;

public partial class UserSubscribtion
{
    public int UserSubscribtionId { get; set; }

    public int UserId { get; set; }

    public int PlanId { get; set; }

    public DateOnly? StartDate { get; set; }

    public string? Status { get; set; }

    public virtual SubscriptionPlan Plan { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
