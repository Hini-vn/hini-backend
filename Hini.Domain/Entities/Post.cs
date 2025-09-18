using System;
using System.Collections.Generic;

namespace Hini.Domain.Entities;

public partial class Post
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string? Caption { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();

    public virtual ICollection<Medium> Media { get; set; } = new List<Medium>();

    public virtual User User { get; set; } = null!;
}
