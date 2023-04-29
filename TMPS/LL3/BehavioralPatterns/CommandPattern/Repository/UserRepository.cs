using CommandPattern.Models;

namespace CommandPattern.Repository;

public class UserRepository : IUserRepository
{
    List<User> users = new List<User>();

    public void SaveUser(User user)
    {
        users.Add(user);
        Console.WriteLine("User saved");
    }

    public User GetByID(int userID)
    {
        foreach(User user in users)
        {
            if (user.Id == userID)
                return user;
        }
        return null!;
    }

    public User GetByUsername(string username)
    {
        foreach(User user in users)
        {
            if (user.Username == username)
                return user;
        }
        return null!;
    }
}
