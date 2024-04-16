namespace News.BL.Implementations;

using News.BL.Interfaces;
using News.DAL.Interfaces;
using News.DAL.Models;

public class UserBL : IUserBL
{
    private readonly IUserDAL userDAL;

    public UserBL(IUserDAL userDAL)
    {
        this.userDAL = userDAL;
    }

    public int? Authenticate(string email, string password)
    {
        string encpass = Encrypt(password);
        foreach(User user in userDAL.FindByEmail(email))
        {
            if (user.Password == encpass)
            {
                return user.Id;
            }
        }
        return null;
    }

    public string Encrypt(string password)
    {
        return password;
    }

    public User? GetUserById(int id)
    {
        return userDAL.FindById(id);
    }

    public int? Register(string firstName, string lastName, string email, string password)
    {
        return userDAL.RegisterUser(firstName, lastName, email, password);
    }
}
