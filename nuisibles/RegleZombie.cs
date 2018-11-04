using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class RegleZombie : IRegleGestion
{
    public List<Nuisible> Regles(List<Nuisible> nuisibles, Nuisible nuisible)
    {
        List<Nuisible> nuisibles_bis = new List<Nuisible>();
        int memoireIndex = -1; // retenir l'index quand on doit modifier un objet qui a un index > a l'index actuellement analysé
        float[] memoirePos = new float[2] {-1, -1};
        foreach (Nuisible autreNuisible in nuisibles)
        {
            if (nuisibles.IndexOf(autreNuisible) >= 0 && nuisibles.IndexOf(nuisible) >= 0 && !autreNuisible.mort)
            {
                if (nuisible.Collision(autreNuisible))
                {
                    if (nuisible.type.Equals("zombie") ^ autreNuisible.type.Equals("zombie"))
                    {
                        if (nuisible.type.Equals("zombie"))
                        {
                            Console.Write("Le " + autreNuisible.type + " à l'index " + nuisibles.IndexOf(autreNuisible) + " est contaminé par le " + nuisible.type + " à l'index " + nuisibles.IndexOf(nuisible) + " !\n");
                            nuisibles_bis.Insert(nuisibles.IndexOf(autreNuisible), new Zombie(nuisible.posX, nuisible.posY));
                            //System.Threading.Thread.Sleep(2000);
                        }
                        else if (autreNuisible.type.Equals("zombie"))
                        {
                            Console.Write("Le " + autreNuisible.type + " à l'index " + nuisibles.IndexOf(autreNuisible) + " à contaminé le " + nuisible.type + " à l'index " + nuisibles.IndexOf(nuisible) + " !\n");
                            nuisibles_bis.Insert(nuisibles.IndexOf(autreNuisible), autreNuisible);
                            memoireIndex = nuisibles.IndexOf(nuisible);
                            memoirePos[0] = autreNuisible.posX;
                            memoirePos[1] = autreNuisible.posY;
                            //System.Threading.Thread.Sleep(2000);
                        }
                    }
                    else
                    {
                        nuisibles_bis.Insert(nuisibles.IndexOf(autreNuisible), autreNuisible);
                    }
                }
                else
                {
                    nuisibles_bis.Insert(nuisibles.IndexOf(autreNuisible), autreNuisible);
                }
            }
            else
            {
                nuisibles_bis.Insert(nuisibles.IndexOf(autreNuisible), autreNuisible);
            }
        }
        if (memoireIndex >= 0) // transforme le "nuisible" en zombie
        {
            nuisibles_bis.RemoveAt(memoireIndex);
            nuisibles_bis.Insert(memoireIndex, new Zombie(memoirePos[0], memoirePos[1]));
        }
        return nuisibles_bis;
    }
}
