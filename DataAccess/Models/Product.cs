using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public string? Images { get; set; }

    public bool? IsPromotional { get; set; }

    public decimal? Score { get; set; }

    public int? Likes { get; set; }

    public int IdStore { get; set; }

    public virtual Store IdStoreNavigation { get; set; } = null!;

    public virtual ICollection<ProductComment> ProductComments { get; set; } = new List<ProductComment>();
}
