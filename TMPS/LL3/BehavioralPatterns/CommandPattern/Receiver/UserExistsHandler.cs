using CommandPattern.Models;
using CommandPattern.Repository;
using System.Data;
using CommandPattern.Receiver;
using CommandPattern.CommandHandlers;

namespace CommandPattern.Receiver;

public class UserExistsHandler : AbstractHandler<User>
{
    public readonly IUserRepository userRepository;

    public UserExistsHandler(IUserRepository userRepository)
	{
        this.userRepository = userRepository;
    }

    public override void Handle(User user)
    {
        var existentUser = userRepository.GetByUsername(user.Username);

        if (existentUser is not null)
        {
            throw new DuplicateNameException();
        }
        Successor.Handle(user);
    }
}

