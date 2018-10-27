using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class RegleZombie : IRegleGestion
{
    public void Regles(List<Nuisible> nuisibles, Nuisible nuisible)
    {
        foreach(Nuisible autreNuisible in nuisibles)
        {
            if (nuisible.Collision(autreNuisible))
            {
                if (nuisible.type.Equals("zombie") ^ autreNuisible.type.Equals("zombie"))
                {
                    Console.Write("Zombie");
                    System.Threading.Thread.Sleep(10000);
                    if (!autreNuisible.type.Equals("zombie"))
                    {
                        nuisibles.Insert(nuisibles.IndexOf(autreNuisible), new Zombie());
                    }
                    else if (!nuisible.type.Equals("zombie"))
                    {
                        nuisibles.Insert(nuisibles.IndexOf(nuisible), new Zombie());
                    }
                    else
                    {
                        nuisibles.Insert(nuisibles.IndexOf(autreNuisible), autreNuisible);
                    }
                }
            }
        }
    }
}
