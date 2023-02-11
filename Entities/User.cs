using System;
using System.Collections.Generic;

namespace SE4_group_A_backend.Entities;

public partial class User
{
    public string Username { get; set; } = null!;

    public string Pasword { get; set; } = null!;

    public string? Token { get; set; }

    public DateTime? LastLoggedIn { get; set; }
}
