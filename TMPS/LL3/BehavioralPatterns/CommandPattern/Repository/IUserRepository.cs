using CommandPattern.Models;

namespace CommandPattern.Repository;

public interface IUserRepository
{
    void SaveUser(User user);
    public User GetByID(int userID);
    public User GetByUsername(string username);
}
