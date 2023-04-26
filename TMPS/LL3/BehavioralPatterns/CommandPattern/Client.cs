using CommandPattern.ConcreteCommand;
using CommandPattern.Repository;
using CommandPattern.Queries;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CommandPattern.CommandHandlers;
using CommandPattern.Invoker;
using CommandPattern.Models;

var emplRepo = new EmployeeRepository();
var saveEmplCommandHandler = new SaveEmployeeCommandHandler(emplRepo);
var employee = new Employee()
{
    Id = 100,
    FirstName = "John",
    LastName = "Smith",
    DateOfBirth = new DateTime(2000, 1, 1),
    Street = "100 Toronto Street",
    City = "Toronto",
    ZipCode = "k1k 1k1"
};
var saveEmployeeCommand = new SaveEmployeeCommand(employee, saveEmplCommandHandler);

var mediator = new Mediator();
mediator.SetCommand(saveEmployeeCommand);
mediator.RunCommand();

var employeeQuery = new GetEmployeeQuery(emplRepo);
var emp = employeeQuery.FindByID(100);

var jsonString = JsonConvert.SerializeObject(
           emp, Formatting.Indented,
           new JsonConverter[] { new StringEnumConverter() });
Console.WriteLine(jsonString);

Console.ReadKey();