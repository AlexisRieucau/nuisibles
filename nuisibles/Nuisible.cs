using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class Nuisible
{
    public float posX;
    public float posY;
    public float posFuturX;
    public float posFuturY;
    public float vitesseX;
    public float vitesseY;
    public string type;

    private Random rand = new Random();
    private readonly float critereDeCollision = 1.0F;

    public Nuisible()
    {
        posX = StaticRandom.tirage(0,500);
        posY = StaticRandom.tirage(0,500);
    }

    public void Deplacement(List<Nuisible> nuisibles)
    {
        switch (StaticRandom.tirage(0, 2))
        {
            case 0:
                if (posX + vitesseX < 500)
                {
                    posFuturX = posX + vitesseX;
                }
                break;
            case 1:
                if (posX - vitesseX > 0)
                {
                    posFuturX = posX - vitesseX;
                }
                break;
        }
        switch (StaticRandom.tirage(0, 2))
        {
            case 0:
                if (posY + vitesseY < 500)
                {
                    posFuturY = posY + vitesseY;
                }
                break;
            case 1:
                if (posY - vitesseY > 0)
                {
                    posFuturY = posY - vitesseY;
                }
                break;
        }

        for(int i = 0; i < vitesseX; i++)
        {
            posX += (float)Math.Round((posFuturX - posX) / vitesseX);
            posY += (float)Math.Round((posFuturY - posY) / vitesseY);
            foreach(Nuisible element in nuisibles)
            {
                if(Math.Abs(element.posX - this.posX) <= 1 && Math.Abs(element.posY - this.posY) <= 1)
                {
                    return;
                }
            }
        }
    }

    public bool Collision(Nuisible nuisible)
    {
        return Math.Sqrt(Math.Pow(this.posX - nuisible.posX,2) + Math.Pow(this.posY - nuisible.posY, 2)) <= critereDeCollision;
    }
}

public static class StaticRandom
{
    private static Random rand = new Random();

    public static int tirage(int min, int max) { return rand.Next(min, max); }
}
