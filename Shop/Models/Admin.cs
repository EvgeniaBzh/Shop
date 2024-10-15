using System;
using System.Collections.Generic;

namespace Shop.Models;

public partial class Admin
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? StoreId { get; set; }

    public int? CourierId { get; set; }

    public virtual Store Id1 { get; set; } = null!;

    public virtual Courier IdNavigation { get; set; } = null!;
}
