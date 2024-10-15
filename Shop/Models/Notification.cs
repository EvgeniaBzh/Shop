using System;
using System.Collections.Generic;

namespace Shop.Models;

public partial class Notification
{
    public int Id { get; set; }

    public int TypeId { get; set; }

    public int Status { get; set; }

    public DateTime DeliveryDate { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual NotificationType IdNavigation { get; set; } = null!;
}
