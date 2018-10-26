using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Ecosysteme
{
    List<Nuisible> nuisibles = new List<Nuisible>();

    public Ecosysteme(ITypeEcosysteme typeEco)
    {
        typeEco.Peupler(nuisibles);
        for (int i = 0; i < 100; i++)
        {
            Console.Write("------ Tick " + i + " ------\n\n");
            foreach (Nuisible element in nuisibles)
            {
                Console.Write("Type = " + element.type + "\t Position = " + element.posX + "," + element.posY + " \t Mort ? " + element.mort +"\n");
                element.Deplacement();
            }
            Console.Write("\n");
        }
    }
}

