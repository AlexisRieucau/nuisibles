using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NuisibleNormal : ITypeNuisible
{
    /// <summary>
    /// definit la maniere dont se deplace le nuisible en parametre
    /// </summary>
    /// <param name="nuisibles">liste des nuisibles presents dans la simulation</param>
    /// <param name="nuisible">nuisible qui doit se deplacer</param>
    public void Deplacement(List<Nuisible> nuisibles, Nuisible nuisible)
    {
        // on commence par prévoir ou le nuisible va se déplacer
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

        //on fait se déplacer le nuisible
        for (int i = 0; i < nuisible.vitesseX; i++)
        {
            nuisible.posX += (float)Math.Round((nuisible.posFuturX - nuisible.posX) / nuisible.vitesseX);
            nuisible.posY += (float)Math.Round((nuisible.posFuturY - nuisible.posY) / nuisible.vitesseY);
            foreach (Nuisible element in nuisibles)
            {
                // on vérifie a chaque instant si le nuisible en croise un autre
                if (nuisible.Collision(element))
                {
                    return;
                }
            }
        }
    }
}
