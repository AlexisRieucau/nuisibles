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
        int choix = StaticRandom.tirage(0, 2);
        foreach (Nuisible autreNuisible in nuisibles)
        {
            if (nuisibles.IndexOf(autreNuisible) >= 0 && nuisibles.IndexOf(nuisible) >= 0 && !autreNuisible.mort)
            {
                if (nuisible.Collision(autreNuisible))
                {
                    if (nuisible.type.Equals("rat") && autreNuisible.type.Equals("pigeon") || nuisible.type.Equals("pigeon") && autreNuisible.type.Equals("rat"))
                    {
                        switch (choix)
                        {
                            case 0:
                                Console.Write("Le " + nuisible.type + " à l'index " + nuisibles.IndexOf(nuisible) + " à tué le " + autreNuisible.type + " à l'index " + nuisibles.IndexOf(autreNuisible) + " !\n");
                                autreNuisible.mort = true;
                                break;
                            case 1:
                                Console.Write("Le " + autreNuisible.type + " à l'index " + nuisibles.IndexOf(autreNuisible) + " à exterminé le " + nuisible.type + " à l'index " + nuisibles.IndexOf(nuisible) + " !\n");
                                memoireIndex = nuisibles.IndexOf(nuisible);
                                break;
                        }
                        //System.Threading.Thread.Sleep(2000);
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
        //return new PigeonMutant(newRegle).Regles(nuisibles, nuisible);
    }
}

class PigeonMutant : Decorator
{
    public PigeonMutant(IRegleGestion newRegle) : base(newRegle)
    {
    }

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
                        //System.Threading.Thread.Sleep(2000);
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
