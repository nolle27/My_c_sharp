using Microsoft.Data.Sqlite;

namespace SqliteTutorialDemo
{

    public class SimpleDatabase
    {
        public void MaakDatabaseEnTabel()
        {

            string connectionString = "Data Source=mijn_database.db";

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();


                string sql = @"
                    CREATE TABLE IF NOT EXISTS Gebruikers (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Naam TEXT
                    );";

                using (var command = new SqliteCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
