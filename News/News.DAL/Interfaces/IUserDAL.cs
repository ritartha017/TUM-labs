namespace News.DAL.Interfaces;

using News.DAL.Models;

public interface IUserDAL
{
    IEnumerable<User> FindByEmail(string email);
    User? FindById(int id);

    int? RegisterUser(string firstName, string lastName, string email, string password);
}
