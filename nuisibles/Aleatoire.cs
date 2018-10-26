using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Aleatoire : ITypeEcosysteme
{
    public void Peupler(List<Nuisible> nuisibles)
    {
        int choix = StaticRandom.tirage(0, 3);
        for (int i = 0; i < 5; i++)
        {
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

