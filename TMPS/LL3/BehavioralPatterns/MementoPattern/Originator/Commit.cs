using System;
using MementoPattern.Memento;

namespace MementoPattern.Originator;

public class Commit
{
	public Guid CommitId;
    public string? Content { get; set; }

	public Commit()
	{
		this.CommitId = Guid.NewGuid();
	}

    public CommitMemento CommitChanges()
	{
		Console.WriteLine($"Saving the state of repo at commit id {this.CommitId}");
		Guid oldCommitId = this.CommitId;
		this.CommitId = Guid.NewGuid();
            return new CommitMemento() { CommitId = oldCommitId, Content = this.Content };
	}

	public void MakeSomeChanges(string content)
	{
		this.Content = this.Content + " " + content;
	}

	public void Restore(CommitMemento memento)
	{
		this.CommitId = memento.CommitId;
		this.Content = memento.Content;
		Console.WriteLine($"HEAD now points at commit id {this.CommitId}");
	}
}

