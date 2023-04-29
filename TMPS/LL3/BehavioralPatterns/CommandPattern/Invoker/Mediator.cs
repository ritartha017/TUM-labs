using CommandPattern.Commands;

namespace CommandPattern.Invoker;

public class Mediator
{
	IUserCommand command;

	public void SetCommand(IUserCommand command)
	{
		this.command = command;
	}

    public void RunCommand()
	{
		command.Execute();
	}
}

