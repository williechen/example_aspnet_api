using System;
using System.Collections.Generic;

namespace QADemo.Domain.Entities;

public partial class Account
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}
