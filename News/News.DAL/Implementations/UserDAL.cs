namespace News.DAL.Implementations;

using System.Collections.Generic;

using Dapper;

using News.DAL.Interfaces;
using News.DAL.Models;

public class UserDAL : IUserDAL
{
    public IEnumerable<User> FindByEmail(string email)
    {
        using var connection = DBConnection.CreateConnection();
        var result = connection.Query<User>("SELECT * FROM [dbo].[User] WHERE Email = @e", new { e = email });
        return result;
    }

    public User? FindById(int id)
    {
        using var connection = DBConnection.CreateConnection();
        return connection.Query<User?>("SELECT * FROM [dbo].[User] WHERE Id = @id", new { id })
            .FirstOrDefault();
    }

    public int? RegisterUser(string firstName, string lastName, string email, string password)
    {
        using var connection = DBConnection.CreateConnection();
        var userId = connection
            .Query<int?>("INSERT INTO [dbo].[User] (FirstName, LastName, Email, Password) VALUES (@f, @l, @e, @p); SELECT SCOPE_IDENTITY();",
            new { f = firstName, l = lastName, e = email, p = password }).FirstOrDefault();
        return userId;
    }
}
