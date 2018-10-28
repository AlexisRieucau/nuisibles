using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Zombie : Nuisible
{
    public Zombie()
    {
        base.type = "zombie";
        base.vitesseX = 1.0F;
        base.vitesseY = 1.0F;
    }
    public Zombie(float x, float y)
    {
        base.type = "zombie";
        base.vitesseX = 1.0F;
        base.vitesseY = 1.0F;
        base.posX = x;
        base.posY = y;
    }
}

