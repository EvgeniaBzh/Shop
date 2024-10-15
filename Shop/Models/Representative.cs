using System;
using System.Collections.Generic;

namespace Shop.Models;

public partial class Representative
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int IsDeleted { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Store> Stores { get; set; } = new List<Store>();
}
