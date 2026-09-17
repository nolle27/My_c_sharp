using System;
using System.Collections.Generic;
using System.Linq;
class List
{
    public void Numbers()
    {
        
        List<int> getallen = new List<int> { 3, 7, 1, 9, 4 };
        Console.WriteLine("De getallen in de lijst:");
        for (int i = 0; i < getallen.Count; i++)
        {
            Console.WriteLine(getallen[i]);
        }
        
        Console.WriteLine(); 
        Console.WriteLine($"Aantal elementen: {getallen.Count}");
        Console.WriteLine($"Het grootste getal: {getallen.Max()}");
    }
}


