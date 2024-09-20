using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Lastname { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Phone { get; set; }

    public int IdStore { get; set; }

    public virtual Store IdStoreNavigation { get; set; } = null!;
}
