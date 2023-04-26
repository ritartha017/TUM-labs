using System;
using CommandPattern.Commands;
using CommandPattern.Models;

namespace CommandPattern.Invoker;

public class Mediator
{
	IEmployeeCommand command;

	public void SetCommand(IEmployeeCommand command)
	{
		this.command = command;
	}

    public void RunCommand()
	{
		command.Execute();
	}
}

