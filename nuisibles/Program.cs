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

        Ecosysteme eco = new Ecosysteme(new Aleatoire());

    }
}
