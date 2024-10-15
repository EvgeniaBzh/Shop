using System;
using System.Collections.Generic;

namespace Shop.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? NotificationId { get; set; }

    public virtual Feedback? Feedback { get; set; }

    public virtual Notification? Notification { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
