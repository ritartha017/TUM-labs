using System;
using MementoPattern.Memento;

namespace MementoPattern.Caretaker;

public class CommitsHistory
{
	public Stack<CommitMemento>? History { get; set; } = new Stack<CommitMemento>();
}

