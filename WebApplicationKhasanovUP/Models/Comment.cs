using System;
using System.Collections.Generic;

namespace WebApplicationKhasanovUP.Models;

public partial class Comment
{
    public int CommentId { get; set; }

    public int AddId { get; set; }

    public int UserId { get; set; }

    public string CommentText { get; set; } = null!;

    public DateOnly CreatedAt { get; set; }

    public virtual Add Add { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
