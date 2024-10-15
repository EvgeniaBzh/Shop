using System;
using System.Collections.Generic;

namespace Shop.Models;

public partial class Store
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? RepresentativeId { get; set; }

    public int IsDeleted { get; set; }

    public virtual Admin? Admin { get; set; }

    public virtual Representative? Representative { get; set; }
}
