using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public string UserPasswordHash { get; set; } = null!;

    public DateTime? UserRegistrationTime { get; set; }

    public DateTime? UserLastLoginTime { get; set; }

    public bool? UserIsBlocked { get; set; }

    public string? RefreshToken { get; set; }
}
