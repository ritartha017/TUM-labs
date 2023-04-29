using System;
using CommandPattern.Models;
using CommandPattern.Repository;

namespace CommandPattern.Receiver;

public class UserCreateHandler : AbstractHandler<User>
{
    public readonly IUserRepository userRepository;

    public UserCreateHandler(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public override void Handle(User user)
    {
        // here we can have complex mapping, any other logic etc
        userRepository.SaveUser(user);
        Console.WriteLine("Mapping was did and the request to save the data was send.");
    }
}

