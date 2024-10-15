using System;
using System.Collections.Generic;

namespace Shop.Models;

public partial class Discount
{
    public int Id { get; set; }

    public string DiscountCode { get; set; } = null!;

    public double Dimensions { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
