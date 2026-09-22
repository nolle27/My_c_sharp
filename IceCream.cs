using System;
using System.Collections.Generic;
using System.Linq;

class IceCream
{
    public string Flavour { get; set; }
    public bool HasTopping { get; set; }

    public IceCream(string flavour, bool hasTopping)
    {
        Flavour = flavour;
        HasTopping = hasTopping;
    }
}

partial class Program
{
    static void Cream()
    {
        
        List<IceCream> iceCreams = new List<IceCream>
        {
            new IceCream("Aardbei", true),
            new IceCream("Vanille", false),
            new IceCream("Chocolade", true)
        };

        foreach (var iceCream in iceCreams)
        {
            string toppingText = iceCream.HasTopping ? "met topping" : "zonder topping";
            Console.WriteLine($"{iceCream.Flavour} {toppingText}");
        }

        int countWithTopping = iceCreams.Count(i => i.HasTopping);
        Console.WriteLine(countWithTopping);
    }
}