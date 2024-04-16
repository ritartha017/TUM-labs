namespace News.DAL.Implementations;

using Microsoft.Data.SqlClient;

public class DBConnection
{
    public static SqlConnection CreateConnection()
    {
        // TODO: Add here pull from config file
        return new SqlConnection("Data Source=EN412241\\MSSQLSERVER_BD;Initial Catalog=NewsDB;Integrated Security=true;Trust Server Certificate=true;");
    }
}
