using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;

public class solution
{
    static void Main(string[] args)
    {
        
        string connectionString = @"Data Source=C:\Users\moerm\Documents\APDA websites\Nieuwe map\Cards.db";
        using var connection = new SqliteConnection(connectionString);
        connection.Open();
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
}

    
