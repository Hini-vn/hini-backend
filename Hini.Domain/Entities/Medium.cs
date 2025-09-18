using System;
using System.Collections.Generic;

namespace Hini.Domain.Entities;

public partial class Medium
{
    public int Id { get; set; }

    public int PostId { get; set; }

    public string Url { get; set; } = null!;

    public string? Type { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Post Post { get; set; } = null!;
}
