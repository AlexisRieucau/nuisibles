using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NuisiblePassif : ITypeNuisible
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
                if (nuisible != element)
                {
                    if (nuisible.Collision(element))
                    {
                        Console.Write("Le passif s'échape !\n");
                        //System.Threading.Thread.Sleep(2000);
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
