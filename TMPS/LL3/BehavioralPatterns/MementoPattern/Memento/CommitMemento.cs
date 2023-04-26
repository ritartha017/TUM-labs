using System;

namespace MementoPattern.Memento;

public class CommitMemento
{
    public Guid CommitId { get; set; }
    public string? Content { get; set; } = null!;
}

