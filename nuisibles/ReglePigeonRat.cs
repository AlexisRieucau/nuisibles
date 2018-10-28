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
        foreach(Nuisible autreNuisible in nuisibles)
        {
            nuisibles_bis.Insert(nuisibles.IndexOf(autreNuisible), autreNuisible);
        }

        return nuisibles_bis;
    }
}
