using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Store
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public int? Category { get; set; }

    public decimal? Score { get; set; }

    public int? Likes { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<StoreComment> StoreComments { get; set; } = new List<StoreComment>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
