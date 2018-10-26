using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Ecosysteme
{
    List<Nuisible> nuisibles = new List<Nuisible>();

    public Ecosysteme(ITypeEcosysteme typeEco, List<IRegleGestion> mesRegles)
    {
        typeEco.Peupler(nuisibles);
        for (int i = 0; i < 10000000000000; i++)
        {
            Console.Write("------ Cycle " + i + " ------\n\n");
            foreach (Nuisible nuisible in nuisibles)
            {
                Console.Write("Type = " + nuisible.type + "\t Position = " + nuisible.posX + ";" + nuisible.posY + "\n");
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
                foreach(IRegleGestion regle in mesRegles)
                    regle.Regles(nuisibles, nuisible);
            }
            Console.Write("\n");
        }
    }
}

