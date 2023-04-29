using CommandPattern.Models;
using CommandPattern.Repository;

namespace CommandPattern.Queries;

public class GetUserQuery
{
    public readonly IUserRepository userRepository;

    public GetUserQuery(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public User FindByID(int userID)
    {
        var user = userRepository.GetByID(userID);

        return user;
    }
}