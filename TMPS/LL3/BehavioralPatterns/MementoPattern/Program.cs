using MementoPattern.Memento;
using MementoPattern.Originator;
using MementoPattern.Caretaker;

Commit initialCommit = new();
Console.WriteLine($"CurrentCommitID: {initialCommit.CommitId}, Content: {initialCommit.Content}\n");

string content = "Some changes.";
initialCommit.MakeSomeChanges(content);

CommitsHistory commits = new CommitsHistory();
commits.History.Push(initialCommit.CommitChanges());
initialCommit.MakeSomeChanges("Some other changes.");
Console.WriteLine($"CurrentCommitID: {initialCommit.CommitId}, Content: {initialCommit.Content}\n");

initialCommit.Restore(commits.History.Pop());
Console.WriteLine($"CurrentCommitID: {initialCommit.CommitId}, Content: {initialCommit.Content}\n");

Console.ReadKey();