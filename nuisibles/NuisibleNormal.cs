using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NuisibleNormal : ITypeNuisible
{
    public void Deplacement(List<Nuisible> nuisibles, Nuisible nuisible)
    {
        switch (StaticRandom.tirage(0, 2))
        {
            case 0:
                if (nuisible.posX + nuisible.vitesseX < 500)
                {
                    nuisible.posFuturX = nuisible.posX + nuisible.vitesseX;
                }
                break;
            case 1:
                if (nuisible.posX - nuisible.vitesseX > 0)
                {
                    nuisible.posFuturX = nuisible.posX - nuisible.vitesseX;
                }
                break;
        }
        switch (StaticRandom.tirage(0, 2))
        {
            case 0:
                if (nuisible.posY + nuisible.vitesseY < 500)
                {
                    nuisible.posFuturY = nuisible.posY + nuisible.vitesseY;
                }
                break;
            case 1:
                if (nuisible.posY - nuisible.vitesseY > 0)
                {
                    nuisible.posFuturY = nuisible.posY - nuisible.vitesseY;
                }
                break;
        }

        for (int i = 0; i < nuisible.vitesseX; i++)
        {
            nuisible.posX += (float)Math.Round((nuisible.posFuturX - nuisible.posX) / nuisible.vitesseX);
            nuisible.posY += (float)Math.Round((nuisible.posFuturY - nuisible.posY) / nuisible.vitesseY);
            foreach (Nuisible element in nuisibles)
            {
                if (nuisible.Collision(element))
                {
                    return;
                }
            }
        }
    }
}
