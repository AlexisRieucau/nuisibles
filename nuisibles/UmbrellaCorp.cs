using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class UmbrellaCorp : ITypeEcosysteme
{
    /// <summary>
    /// rempli l'ecosysteme avec au moins 50% de zombies et le reste en rats et pigeons
    /// </summary>
    /// <param name="nuisibles">liste des nuisibles presents dans l'ecosysteme</param>
    public void Peupler(List<Nuisible> nuisibles)
    {
        int choix = StaticRandom.tirage(0, 3);
        for (int i = 0; i < Constantes.nbNuisibles/2; i++)
        {
            nuisibles.Add(new Zombie());
            choix = StaticRandom.tirage(0, 3);
            switch (choix)
            {
                case 0:
                    nuisibles.Add(new Rat());
                    break;
                case 1:
                    nuisibles.Add(new Pigeon());
                    break;
                case 2:
                    nuisibles.Add(new Zombie());
                    break;
            }
        }
    }
}
