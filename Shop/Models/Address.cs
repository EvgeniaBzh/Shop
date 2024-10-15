using System;
using System.Collections.Generic;

namespace Shop.Models;

public partial class Address
{
    public int Id { get; set; }

    public string Settlement { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string HouseNumber { get; set; } = null!;

    public string? ApartmentNumber { get; set; }

    public int ZipCode { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
