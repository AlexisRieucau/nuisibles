using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Ecosysteme
{
    List<Nuisible> nuisibles = new List<Nuisible>();

    /// <summary>
    /// définition du fonctionnement de l'ecosysteme
    /// </summary>
    /// <param name="typeEco">type d'ecosysteme (Aleatoire, UmbrellaCorp, Citadin)</param>
    /// <param name="mesRegles">liste des regles qui définissent le comportant des habitants de l'ecosysteme</param>
    public Ecosysteme(ITypeEcosysteme typeEco, List<IRegleGestion> mesRegles)
    {
        List<Nuisible> nuisiblesTampon = new List<Nuisible>();
        
        typeEco.Peupler(nuisibles);
        nuisiblesTampon.AddRange(nuisibles); // on travaille sur le tampon et on remplace la liste nuisible
        for (int i = 0; i < Constantes.nbCyclesSimulation; i++)
        {
            Console.Write("------ Cycle " + i + " ------\n\n");
            foreach (Nuisible nuisible in nuisibles)
            {
                if (!nuisible.mort)
                {
                    Console.Write("Type = " + nuisible.type + "\t Position = " + nuisible.posX + ";" + nuisible.posY + "\t index = " + nuisibles.IndexOf(nuisible) + "\tpassif ? "+nuisible.passif+"\n");
                    nuisible.Deplacement(nuisibles);
                    foreach (IRegleGestion regle in mesRegles)
                    {
                        nuisiblesTampon.AddRange(regle.Regles(nuisiblesTampon, nuisible));
                        nuisiblesTampon.RemoveRange(0,Constantes.nbNuisibles);
                    }
                    System.Threading.Thread.Sleep(10); // ralentis la simulation pour l'affichage en console
                }
            }
            nuisibles.AddRange(nuisiblesTampon);
            nuisibles.RemoveRange(0, nuisibles.Count() - nuisiblesTampon.Count());
            Console.Write("\n");
        }
    }
}

