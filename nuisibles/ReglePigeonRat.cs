using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ReglePigeonRat : IRegleGestion
{
    public List<Nuisible> Regles(List<Nuisible> nuisibles, Nuisible nuisible)
    {
        List<Nuisible> nuisibles_bis = new List<Nuisible>();
        int memoireIndex = -1; // retenir l'index quand on doit modifier un objet qui a un index > a l'index actuellement analysé
        float[] memoirePos = new float[2] { -1, -1 };
        foreach (Nuisible autreNuisible in nuisibles)
        {
            if (nuisibles.IndexOf(autreNuisible) >= 0 && nuisibles.IndexOf(nuisible) >= 0)
            {
                if (nuisible.Collision(autreNuisible))
                {
                    if (nuisible.type.Equals("rat") && autreNuisible.type.Equals("pigeon") || nuisible.type.Equals("pigeon") && autreNuisible.type.Equals("rat"))
                    {
                        if (autreNuisible.type.Equals("rat"))
                        {
                            Console.Write("Le " + autreNuisible.type + " à l'index " + nuisibles.IndexOf(autreNuisible) + " à tué le " + nuisible.type + " à l'index " + nuisibles.IndexOf(nuisible) + " !\n");
                            nuisibles_bis.Insert(nuisibles.IndexOf(autreNuisible), new Zombie(nuisible.posX, nuisible.posY));
                            System.Threading.Thread.Sleep(5000);
                        }
                        else if (autreNuisible.type.Equals("pigeon"))
                        {
                            Console.Write("Le " + autreNuisible.type + " à l'index " + nuisibles.IndexOf(autreNuisible) + " à exterminé le " + nuisible.type + " à l'index " + nuisibles.IndexOf(nuisible) + " !\n");
                            nuisibles_bis.Insert(nuisibles.IndexOf(autreNuisible), autreNuisible);
                            memoireIndex = nuisibles.IndexOf(nuisible);
                            memoirePos[0] = autreNuisible.posX;
                            memoirePos[1] = autreNuisible.posY;
                            System.Threading.Thread.Sleep(5000);
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
