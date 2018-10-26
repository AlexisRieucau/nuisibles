using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class Nuisible
{
    public int posX;
    public int posY;
    public int vitesseX;
    public int vitesseY;
    public bool mort = false;
    public string type;

    private Random rand = new Random();
    private int choix = 0;

    public Nuisible()
    {
        posX = StaticRandom.tirage(0,500);
        posY = StaticRandom.tirage(0,500);
    }

    public void Deplacement()
    {
        choix = StaticRandom.tirage(0, 2); ;
        switch (choix)
        {
            case 0:
                if (posX < 497)
                {
                    posX += vitesseX;
                }
                break;
            case 1:
                if (posX > 3)
                {
                    posX -= vitesseX;
                }
                break;
        }
        choix = StaticRandom.tirage(0, 2); ;
        switch (choix)
        {
            case 0:
                if (posY < 497)
                {
                    posY += vitesseY;
                }
                break;
            case 1:
                if (posY > 3)
                {
                    posY -= vitesseY;
                }
                break;
        }
    }
}

public static class StaticRandom
{
    private static Random rand = new Random();

    public static int tirage(int min, int max) { return rand.Next(min, max); }
}
