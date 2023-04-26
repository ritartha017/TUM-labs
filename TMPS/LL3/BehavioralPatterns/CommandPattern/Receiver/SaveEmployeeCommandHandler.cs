using System;
using CommandPattern.Models;
using CommandPattern.Repository;

namespace CommandPattern.CommandHandlers;

public class SaveEmployeeCommandHandler
{
    public readonly IEmployeeRepository employeeRepository;

    public SaveEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    {
        this.employeeRepository = employeeRepository;
    }

    public void SaveEmployeeData(Employee employee)
    {
        // here we can have complex mapping, any other logic etc
        employeeRepository.SaveEmployee(employee);
        Console.WriteLine("Mapping was did and the request to save the data was send.");
    }
}
