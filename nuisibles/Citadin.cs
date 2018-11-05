using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Citadin : ITypeEcosysteme
{
    /// <summary>
    /// rempli l'ecosysteme avec uniquement des pigeons et des rats en proportions aleatoires
    /// </summary>
    /// <param name="nuisibles">liste des nuisibles préents dans l'ecosysteme</param>
    public void Peupler(List<Nuisible> nuisibles)
    {
        int choix = StaticRandom.tirage(0, 2);
        for (int i = 0; i < 200; i++)
        {
            choix = StaticRandom.tirage(0, 2);
            switch (choix)
            {
                case 0:
                    nuisibles.Add(new Rat());
                    break;
                case 1:
                    nuisibles.Add(new Pigeon());
                    break;
            }
        }
    }
}
