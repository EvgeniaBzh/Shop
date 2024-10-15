using System;
using System.Collections.Generic;

namespace Shop.Models;

public partial class Payment
{
    public int Id { get; set; }

    public double AmountOfMoney { get; set; }

    public DateTime PaymentDate { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
