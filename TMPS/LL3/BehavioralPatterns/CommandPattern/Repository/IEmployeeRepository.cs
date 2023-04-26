using System;
using CommandPattern.Models;

namespace CommandPattern.Repository;

public interface IEmployeeRepository
{
    void SaveEmployee(Employee employee);
    public Employee GetByID(int employeeID);
}

