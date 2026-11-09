using System;
using Microsoft.Data.Sqlite;

public class Tables
{
    static void Table(string[] args)
    {
        string connectionString = @"Data Source=C:\Users\moerm\Documents\APDA websites\Nieuwe map";
        
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        // 1. Tabel aanmaken en eventueel vullen als deze nog niet bestaat
        EnsureTableAndDataCreated(connection);

        // 2. Woordenkenner spel starten
        var command = connection.CreateCommand();
        command.CommandText = "SELECT english_word, french_word FROM word_pairs";
        using var reader = command.ExecuteReader();
        
        int score = 0;
        int total = 0;
        
        Console.WriteLine("=== WOORDENKENNER ===");
        Console.WriteLine("Vertaal de volgende Engelse woorden naar het Frans:\n");

        while (reader.Read())
        {
            string englishWord = reader.GetString(0);
            string correctFrenchWord = reader.GetString(1);

            total++;

            Console.Write($"Vraag {total}: Wat is de vertaling van '{englishWord}'? ");
            string? userResponse = Console.ReadLine()?.Trim();

            if (string.Equals(userResponse, correctFrenchWord, StringComparison.OrdinalIgnoreCase))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Correct! Goed gedaan.\n");
                score++;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Fout. Het juiste antwoord was: {correctFrenchWord}\n");
            }

            Console.ResetColor();
        }
        
        Console.WriteLine("-------------------------");
        Console.WriteLine($"Klaar! Je hebt {score} op {total} woorden juist.");
    }

    private static void EnsureTableAndDataCreated(SqliteConnection connection)
    {
        var command = connection.CreateCommand();
        
       
        command.CommandText = @"C:\Users\moerm\Documents\APDA websites\Nieuwe map
            CREATE TABLE IF NOT EXISTS word_pairs (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                english_word TEXT NOT NULL,
                french_word TEXT NOT NULL
            );
        ";
        command.ExecuteNonQuery();

        command.CommandText = "SELECT COUNT(*) FROM word_pairs;";
        long count = (long)command.ExecuteScalar()!;

        if (count == 0)
        {
            command.CommandText = @"Data Source=C:\Users\moerm\Documents\APDA websites\Nieuwe map\Cards.db
                INSERT INTO word_pairs (english_word, french_word) VALUES 
                ('Hello', 'Bonjour'),
                ('Cat', 'Chat'),
                ('Dog', 'Chien'),
                ('House', 'Maison'),
                ('Water', 'Eau');
            ";
            command.ExecuteNonQuery();
            Console.WriteLine("Database en voorbeeldwoorden succesvol aangemaakt!\n");
        }
    }
}