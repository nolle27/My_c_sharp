using System;

public class Question
{
    public void Eafc()
    {
        Console.Write("Geef je naam: ");
        string naam = Console.ReadLine();

        Console.Write("Geef je leeftijd: ");
        int leeftijd = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Hallo, " + naam + "! Je bent " + leeftijd + " jaar oud.");
        
    }

}