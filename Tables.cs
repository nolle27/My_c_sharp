using Microsoft.Data.Sqlite;



public class Tables
{
    public static void pain()
    {
        try
        {
            using var connection = new SqliteConnection(@"Data Source=C:\db\pub.db");
            connection.Open();

            // SQL-commando om een tabel aan te maken
            string sqlQuery = @"
                CREATE TABLE IF NOT EXISTS publishers (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    name TEXT NOT NULL
                );";

            using var command = new SqliteCommand(sqlQuery, connection);
            command.ExecuteNonQuery();

            Console.WriteLine("Table created successfully!");
        }
        catch (SqliteException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}