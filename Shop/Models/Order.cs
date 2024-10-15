using System;
using System.Collections.Generic;

namespace Shop.Models;

public partial class Order
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public decimal Price { get; set; }

    public DateTime OrderDate { get; set; }

    public DateTime? ShippingDate { get; set; }

    public int? ShippingAddressId { get; set; }

    public int Status { get; set; }

    public int? PaymentId { get; set; }

    public int? CourierId { get; set; }

    public int? DiscountId { get; set; }

    public DateTime LastEditted { get; set; }

    public int? ProductId { get; set; }

    public virtual Courier? Courier { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Discount? Discount { get; set; }

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    public virtual Payment? Payment { get; set; }

    public virtual Address? ShippingAddress { get; set; }
}
