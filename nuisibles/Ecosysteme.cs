using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Ecosysteme
{
    List<Nuisible> nuisibles = new List<Nuisible>();
    List<Nuisible> nuisiblesTampon = new List<Nuisible>();

    public Ecosysteme(ITypeEcosysteme typeEco, List<IRegleGestion> mesRegles)
    {
        typeEco.Peupler(nuisibles);
        nuisiblesTampon.AddRange(nuisibles); // on travaille sur le tampon et on remplace la liste nuisible
        for (int i = 0; i < 100000; i++)
        {
            Console.Write("------ Cycle " + i + " ------\n\n");
            foreach (Nuisible nuisible in nuisibles)
            {
                if (!nuisible.mort)
                {
                    Console.Write("Type = " + nuisible.type + "\t Position = " + nuisible.posX + ";" + nuisible.posY + "\t index = " + nuisibles.IndexOf(nuisible) + "\n");
                    nuisible.Deplacement(nuisibles);
                    foreach (IRegleGestion regle in mesRegles)
                    {
                        nuisiblesTampon.AddRange(regle.Regles(nuisiblesTampon, nuisible));
                        nuisiblesTampon.RemoveRange(0,200);
                    }
                    System.Threading.Thread.Sleep(10);
                }
            }
            nuisibles.AddRange(nuisiblesTampon);
            nuisibles.RemoveRange(0, nuisibles.Count() - nuisiblesTampon.Count());
            Console.Write("\n");
        }
    }
}

