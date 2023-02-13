using System;
using System.Collections.Generic;

namespace SE4_group_A_backend.Entities;

public partial class Achievement
{
    public string AchievementId { get; set; } = null!;

    public string StudentId { get; set; } = null!;

    public DateTime AchievementDate { get; set; }

    public string Description { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
