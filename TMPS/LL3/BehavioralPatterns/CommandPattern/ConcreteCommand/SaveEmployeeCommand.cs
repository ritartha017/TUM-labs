using System;
using CommandPattern.Commands;
using CommandPattern.Models;
using CommandPattern.Repository;
using CommandPattern.CommandHandlers;

namespace CommandPattern.ConcreteCommand;

public class SaveEmployeeCommand : IEmployeeCommand
{
    public readonly SaveEmployeeCommandHandler saveEmployeeCommandHandler;
    public readonly Employee employee;

    public SaveEmployeeCommand(Employee employee, SaveEmployeeCommandHandler saveEmployeeCommandHandler)
    {
        this.saveEmployeeCommandHandler = saveEmployeeCommandHandler;
        this.employee = employee;
    }

    public void Execute()
    {
        saveEmployeeCommandHandler.SaveEmployeeData(this.employee);
    }
}

