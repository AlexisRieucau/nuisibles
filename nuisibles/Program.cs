using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        Console.Write("Bienvenue dans l'écosystème !\n\n");

        //List<IRegleGestion> mesRegles = new List<IRegleGestion> { new RegleZombie(), new ReglePigeonRat() }; // Ecosysteme normal
        List<IRegleGestion> mesRegles = new List<IRegleGestion> { new RegleZombie(), new PigeonMutant(new ReglePigeonRat()) }; // Pigeons mutants

        Ecosysteme eco = new Ecosysteme(new Aleatoire(), mesRegles); // on créé l'ecosysteme en choisissant son type

    }
}
