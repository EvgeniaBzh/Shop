using System;
using System.Collections.Generic;

namespace Shop.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public double Price { get; set; }

    public double Weight { get; set; }

    public int StockQuantity { get; set; }

    public int? CategoryId { get; set; }

    public int? BrandId { get; set; }

    public int? RepresentativeId { get; set; }

    public string Image { get; set; } = null!;

    public int? FeedbackId { get; set; }

    public DateTime LastEditted { get; set; }

    public int IsDeleted { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Feedback? Feedback { get; set; }

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    public virtual Representative? Representative { get; set; }
}
