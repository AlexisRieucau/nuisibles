using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class RegleZombie : IRegleGestion
{
    /// <summary>
    /// définit les regles a suivre dans le cas ou un zombie rencontre un autre nuisible
    /// </summary>
    /// <param name="nuisibles">liste des nuisibles présents dans la simulation</param>
    /// <param name="nuisible">le nuisible actuellement analysé dans la simulation</param>
    /// <returns></returns>
    public List<Nuisible> Regles(List<Nuisible> nuisibles, Nuisible nuisible)
    {
        List<Nuisible> nuisibles_bis = new List<Nuisible>(); // liste tampon
        int memoireIndex = -1; // retenir l'index quand on doit modifier un objet qui a un index > a l'index actuellement analysé
        float[] memoirePos = new float[2] {-1, -1}; // retenir la position de l'objet a l'index memoireIndex
        // on va comparer le nuisible actuellement analysé à tous les autres nusibles de l'ecosysteme
        foreach (Nuisible autreNuisible in nuisibles)
        {
            // quand un zombie contamine un autre nuisible, l'index du second passe temporairement a -1, on ne doit donc pas le considérer ici
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
                            //System.Threading.Thread.Sleep(2000); // Pause pour debug
                        }
                        else if (autreNuisible.type.Equals("zombie"))
                        {
                            Console.Write("Le " + autreNuisible.type + " à l'index " + nuisibles.IndexOf(autreNuisible) + " à contaminé le " + nuisible.type + " à l'index " + nuisibles.IndexOf(nuisible) + " !\n");
                            nuisibles_bis.Insert(nuisibles.IndexOf(autreNuisible), autreNuisible); // on laisse le zombie a sa place, on on modifiera la position de l'autre nuisible en fin de methode
                            memoireIndex = nuisibles.IndexOf(nuisible);
                            memoirePos[0] = autreNuisible.posX;
                            memoirePos[1] = autreNuisible.posY;
                            //System.Threading.Thread.Sleep(2000); // Pause pour debug
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
