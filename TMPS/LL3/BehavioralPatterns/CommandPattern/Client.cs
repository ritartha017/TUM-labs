using CommandPattern.ConcreteCommand;
using CommandPattern.Repository;
using CommandPattern.Queries;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CommandPattern.CommandHandlers;
using CommandPattern.Invoker;
using CommandPattern.Models;

try
{
    var userRepo = new UserRepository();
    var saveUserCommandHandler = new SaveUserCommandHandler(userRepo);
    var user = new User()
    {
        Id = 100,
        FirstName = "John",
        LastName = "Smith",
        Username = "John777",
        DateOfBirth = new DateTime(2000, 1, 1),
        Street = "100 Toronto Street",
        City = "Toronto",
        ZipCode = "k1k 1k1"
    };
    var saveUserCommand = new SaveUserCommand(user, saveUserCommandHandler);
    var mediator = new Mediator();
    mediator.SetCommand(saveUserCommand);
    mediator.RunCommand();

    var userQuery = new GetUserQuery(userRepo);
    var userResp = userQuery.FindByID(100);
    var jsonString = JsonConvert.SerializeObject(
               userResp, Formatting.Indented,
               new JsonConverter[] { new StringEnumConverter() });
    Console.WriteLine(jsonString);

    var user2 = new User()
    {
        Id = 101,
        FirstName = "John",
        LastName = "Smith",
        Username = "ZZZ",
        DateOfBirth = new DateTime(2000, 1, 1),
        Street = "100 Toronto Street",
        City = "Toronto",
        ZipCode = "k1k 1k1"
    };
    saveUserCommand = new SaveUserCommand(user2, saveUserCommandHandler);
    mediator.SetCommand(saveUserCommand);
    mediator.RunCommand();
}
catch(Exception ex)
{
    Console.WriteLine(ex.ToString());
}
Console.ReadKey();