using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NuisiblePassif : ITypeNuisible
{
    /// <summary>
    /// definit la maniere dont se deplace le nuisible en parametre, dans le cas ou ce dernier est passif
    /// </summary>
    /// <param name="nuisibles">liste des nuisibles presents dans la simulation</param>
    /// <param name="nuisible">nuisible qui doit se deplacer</param>
    public void Deplacement(List<Nuisible> nuisibles, Nuisible nuisible)
    {
        // on commence par prévoir ou le nuisible va se deplacer
        switch (StaticRandom.tirage(0, 2))
        {
            case 0:
                if (nuisible.posX + nuisible.vitesseX < Constantes.tailleTerrainX)
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
                if (nuisible.posY + nuisible.vitesseY < Constantes.tailleTerrainY)
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

        // on fait se déplacer le nuisible
        for (int i = 0; i < nuisible.vitesseX; i++)
        {
            nuisible.posX += (float)Math.Round((nuisible.posFuturX - nuisible.posX) / nuisible.vitesseX);
            nuisible.posY += (float)Math.Round((nuisible.posFuturY - nuisible.posY) / nuisible.vitesseY);
            foreach (Nuisible element in nuisibles)
            {
                if (nuisible != element)
                {
                    // on vérifie a chaque instant si le nuisible en croise un autre
                    if (nuisible.Collision(element))
                    {
                        Console.Write("Le passif s'échape !\n");
                        //System.Threading.Thread.Sleep(2000); // Pause pour debug
                        for (int j = 0; j < 5 * nuisible.vitesseX; j++)
                        {
                            if (nuisible.passif == true)
                            {
                                if (nuisible.posX >= element.posX)
                                {
                                    nuisible.posX += (float)Math.Round((nuisible.posFuturX - nuisible.posX) / nuisible.vitesseX);
                                }
                                else
                                {
                                    nuisible.posX -= (float)Math.Round((nuisible.posFuturX - nuisible.posX) / nuisible.vitesseX);
                                }
                                if (nuisible.posY >= element.posY)
                                {
                                    nuisible.posY += (float)Math.Round((nuisible.posFuturY - nuisible.posY) / nuisible.vitesseY);
                                }
                                else
                                {
                                    nuisible.posY -= (float)Math.Round((nuisible.posFuturY - nuisible.posY) / nuisible.vitesseY);
                                }
                            }
                            if (element.passif == true)
                            {
                                if (nuisible.posX >= element.posX)
                                {
                                    nuisible.posX -= (float)Math.Round((nuisible.posFuturX - nuisible.posX) / nuisible.vitesseX);
                                }
                                else
                                {
                                    nuisible.posX += (float)Math.Round((nuisible.posFuturX - nuisible.posX) / nuisible.vitesseX);
                                }
                                if (nuisible.posY >= element.posY)
                                {
                                    nuisible.posY -= (float)Math.Round((nuisible.posFuturY - nuisible.posY) / nuisible.vitesseY);
                                }
                                else
                                {
                                    nuisible.posY += (float)Math.Round((nuisible.posFuturY - nuisible.posY) / nuisible.vitesseY);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
