using System;

public class Statements
{
    // Opdracht 6: Eenvoudige Methode
    public static void Greet()
    {
        Console.WriteLine("Hallo vanuit een methode!");
    }

    // Opdracht 4: If-Else Statements
    public void CheckGetal()
    {
        Console.Write("Voer een getal in: ");
        double getal = Convert.ToDouble(Console.ReadLine());

        if (getal > 0)
        {
            Console.WriteLine("Het getal is positief.");
        }
        else if (getal < 0)
        {
            Console.WriteLine("Het getal is negatief.");
        }
        else
        {
            Console.WriteLine("Het getal is nul.");
        }
        Statements myStatements = new Statements();
        myStatements.CheckGetal();
    }
}


