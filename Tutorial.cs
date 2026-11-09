using Microsoft.Data.Sqlite;

namespace SQLiteDemo;

public class Tutorial
{
    public static void Mai()
    {
        try
        {
            using var connection = new SqliteConnection(@"Data Source=C:\db\pub.db");
            connection.Open();

            Console.WriteLine("Connected to the SQLite database!");
        }
        catch (SqliteException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}