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
                Console.Write("Type = " + nuisible.type + "\t Position = " + nuisible.posX + ";" + nuisible.posY + "\t index = " + nuisibles.IndexOf(nuisible) + "\n");
                nuisible.Deplacement(nuisibles);
                /*foreach(Nuisible autreNuisible in nuisibles)
                {
                    if (nuisible.Collision(autreNuisible))
                    {
                        
                        if (nuisible.type.Equals("zombie") ^ autreNuisible.type.Equals("zombie"))
                        {
                            IRegleGestion zombie = new RegleZombie();
                            nuisibles = zombie.Regles(nuisibles, nuisibles.IndexOf(nuisible), nuisibles.IndexOf(autreNuisible));
                        }
                        else if(!nuisible.type.Equals("zombie") && !autreNuisible.type.Equals("zombie") && (nuisible.type.Equals("pigeon") ^ autreNuisible.type.Equals("pigeon")) && (nuisible.type.Equals("rat") ^ autreNuisible.type.Equals("rat")))
                        {
                            IRegleGestion pigeonRat = new ReglePigeonRat();
                            nuisibles = pigeonRat.Regles(nuisibles, nuisibles.IndexOf(nuisible), nuisibles.IndexOf(autreNuisible));
                        }
                    }
                }*/
                /*foreach (IRegleGestion regle in mesRegles)
                {
                    nuisiblesTampon.AddRange(regle.Regles(nuisiblesTampon, nuisible));
                    nuisiblesTampon.RemoveRange(0,200);
                }*/
                nuisiblesTampon.AddRange(new RegleZombie().Regles(nuisiblesTampon, nuisible));
                nuisiblesTampon.RemoveRange(0, 200);
                System.Threading.Thread.Sleep(10);
            }
            nuisibles.AddRange(nuisiblesTampon);
            nuisibles.RemoveRange(0, 200);
            Console.Write("\n");
        }
    }
}

