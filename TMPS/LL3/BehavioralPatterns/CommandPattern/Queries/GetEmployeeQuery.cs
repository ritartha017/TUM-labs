using System;
using CommandPattern.Models;
using CommandPattern.Repository;

namespace CommandPattern.Queries;

public class GetEmployeeQuery
{
    public readonly IEmployeeRepository employeeRepository;

    public GetEmployeeQuery(IEmployeeRepository employeeRepository)
    {
        this.employeeRepository = employeeRepository;
    }

    public Employee FindByID(int employeeID)
    {
        var emp = employeeRepository.GetByID(employeeID);

        return emp;
    }
}