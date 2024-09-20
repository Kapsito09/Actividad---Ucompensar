using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class ProductComment
{
    public int Id { get; set; }

    public decimal? Score { get; set; }

    public string? Comment { get; set; }

    public int CustomerId { get; set; }

    public int ProductId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
