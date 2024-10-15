using System;
using System.Collections.Generic;

namespace Shop.Models;

public partial class Courier
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Status { get; set; }

    public virtual Admin? Admin { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
