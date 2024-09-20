using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class StoreComment
{
    public int Id { get; set; }

    public decimal? Score { get; set; }

    public string? Comment { get; set; }

    public int CustomerId { get; set; }

    public int StoreId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Store Store { get; set; } = null!;
}
