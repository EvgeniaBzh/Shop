using System;
using System.Collections.Generic;

namespace Shop.Models;

public partial class Feedback
{
    public int Id { get; set; }

    public int StarsNumber { get; set; }

    public string? Text { get; set; }

    public string? Photo { get; set; }

    public int CustomerId { get; set; }

    public virtual Customer IdNavigation { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
