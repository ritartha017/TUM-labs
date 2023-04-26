using System;
using CommandPattern.Models;

namespace CommandPattern.Repository;

public class EmployeeRepository : IEmployeeRepository
{
    List<Employee> employees = new List<Employee>();

    public void SaveEmployee(Employee employee)
    {
        employees.Add(employee);
        Console.WriteLine("Empl saved");
    }

    public Employee GetByID(int employeeID)
    {
        return new Employee()
        {
            Id = 100,
            FirstName = "John",
            LastName = "Smith",
            DateOfBirth = new DateTime(2000, 1, 1),
            Street = "100 Toronto Street",
            City = "Toronto",
            ZipCode = "k1k 1k1"
        };
    }
}

