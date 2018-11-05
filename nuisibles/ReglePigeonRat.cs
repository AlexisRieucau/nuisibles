using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ReglePigeonRat : IRegleGestion
{
    /// <summary>
    /// définit les regles a suivre dans le cas ou un pigeon rencontre un rat
    /// </summary>
    /// <param name="nuisibles">liste des nuisibles présents dans la simulation</param>
    /// <param name="nuisible">le nuisible actuellement analysé dans la simulation</param>
    /// <returns></returns>
    public List<Nuisible> Regles(List<Nuisible> nuisibles, Nuisible nuisible)
    {
        List<Nuisible> nuisibles_bis = new List<Nuisible>(); // lste tampon
        int memoireIndex = -1; // retenir l'index quand on doit modifier un objet qui a un index > a l'index actuellement analysé
        int choix = StaticRandom.tirage(0, 2);
        // on va comparer le nuisible actuellement analysé à tous les autres nusibles de l'ecosysteme
        foreach (Nuisible autreNuisible in nuisibles)
        {
            if (nuisibles.IndexOf(autreNuisible) >= 0 && nuisibles.IndexOf(nuisible) >= 0 && !autreNuisible.mort)
            {
                if (nuisible.Collision(autreNuisible))
                {
                    if (nuisible.type.Equals("rat") && autreNuisible.type.Equals("pigeon") || nuisible.type.Equals("pigeon") && autreNuisible.type.Equals("rat"))
                    {
                        // 1 chance sur 2
                        switch (choix)
                        {
                            case 0: // le premier nuisible a tué le second
                                Console.Write("Le " + nuisible.type + " à l'index " + nuisibles.IndexOf(nuisible) + " à tué le " + autreNuisible.type + " à l'index " + nuisibles.IndexOf(autreNuisible) + " !\n");
                                autreNuisible.mort = true;
                                break;
                            case 1: // le second nuisible a tué le premier
                                Console.Write("Le " + autreNuisible.type + " à l'index " + nuisibles.IndexOf(autreNuisible) + " à exterminé le " + nuisible.type + " à l'index " + nuisibles.IndexOf(nuisible) + " !\n");
                                memoireIndex = nuisibles.IndexOf(nuisible);
                                break;
                        }
                        //System.Threading.Thread.Sleep(2000); // Pause pour debug
                    }
                }
            }
            nuisibles_bis.Add(autreNuisible);
        }
        if (memoireIndex >= 0) // définit le nuisible mort
        {
            nuisibles_bis[memoireIndex].mort = true;
        }
        return nuisibles_bis;
    }
}

/// <summary>
/// classe abstraire du design pattern decorator
/// </summary>
abstract class Decorator : IRegleGestion
{
    protected IRegleGestion newRegle;
    
    public Decorator(IRegleGestion newRegle)
    {
        this.newRegle = newRegle;
    }

    virtual public List<Nuisible> Regles(List<Nuisible> nuisibles, Nuisible nuisible)
    {
        return newRegle.Regles(nuisibles, nuisible);
    }
}

/// <summary>
/// definition des ajouts a la classe ReglePigeonRat a l'aide du decorator
/// </summary>
class PigeonMutant : Decorator
{
    /// <summary>
    /// constructeur qui appelle le constructeur de la classe parent
    /// </summary>
    /// <param name="newRegle">ReglePigeonRat</param>
    public PigeonMutant(IRegleGestion newRegle) : base(newRegle)
    {
    }

    /// <summary>
    /// définit le comportement du pigeon en fonction de s'il est mutant ou pas
    /// </summary>
    /// <param name="nuisibles">liste des nuisibles présents dans la simulation</param>
    /// <param name="nuisible">le nuisible actuellement analysé dans la simulation</param>
    /// <returns></returns>
    public override List<Nuisible> Regles(List<Nuisible> nuisibles, Nuisible nuisible)
    {
        List<Nuisible> nuisibles_bis = new List<Nuisible>();
        nuisibles_bis = base.Regles(nuisibles, nuisible);
        foreach (Nuisible element in nuisibles_bis)
        {
            if (element.type.Equals("pigeon") && element.mort == true)
            {
                switch (element.mutant)
                {
                    case true: // pigeon mutant -> survit
                        Console.Write("Le pigeon à survécu !\n");
                        //System.Threading.Thread.Sleep(2000); // Pause pour debug
                        element.mort = false;
                        break;
                    case false: // pigeon normal -> meurt
                        break;
                }
            }
        }
        return nuisibles_bis;
    }
}
