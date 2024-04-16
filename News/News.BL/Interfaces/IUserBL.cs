namespace News.BL.Interfaces;

using News.DAL.Models;

public interface IUserBL
{
    int? Authenticate(string email, string password);
    User? GetUserById(int id);

    int? Register(string firstName, string lastName, string email, string password);
}
