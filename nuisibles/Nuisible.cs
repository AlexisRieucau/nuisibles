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
    public bool mort;
    public bool mutant;
    public bool passif;

    private Random rand = new Random();
    private readonly float critereDeCollision = 1.0F;

    public Nuisible()
    {
        posX = StaticRandom.tirage(0,500);
        posY = StaticRandom.tirage(0,500);
        mort = false;
        switch(StaticRandom.tirage(0,2))
        {
            case 0:
                mutant = false;
                break;
            case 1:
                mutant = true;
                break;
        }
        if(StaticRandom.tirage(0,10) <= 8) // 20% de passifs
        {
            passif = false;
        }
        else
        {
            passif = true;
        }
    }

    public void Deplacement(List<Nuisible> nuisibles)
    {
        List <ITypeNuisible> typeDeNuisible = new List<ITypeNuisible> { new NuisibleNormal(), new NuisiblePassif() };
        switch(this.passif)
        {
            case true:
                typeDeNuisible[1].Deplacement(nuisibles, this);
                break;
            case false:
                typeDeNuisible[0].Deplacement(nuisibles, this);
                break;
        }
        /*switch (StaticRandom.tirage(0, 2))
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
            foreach(Nuisible nuisible in nuisibles)
            {
                if(this.Collision(nuisible))
                {
                    return;
                }
            }
        }*/


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
