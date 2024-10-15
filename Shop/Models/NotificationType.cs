using System;
using System.Collections.Generic;

namespace Shop.Models;

public partial class NotificationType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual Notification? Notification { get; set; }
}
