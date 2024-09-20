using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Lastname { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<ProductComment> ProductComments { get; set; } = new List<ProductComment>();

    public virtual ICollection<StoreComment> StoreComments { get; set; } = new List<StoreComment>();
}
