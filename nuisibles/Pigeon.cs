using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Pigeon : Nuisible
{
    public Pigeon()
    {
        base.type = "pigeon";
        base.vitesseX = 3.0F;
        base.vitesseY = 3.0F;
    }
    public Pigeon(float x, float y)
    {
        base.type = "pigeon";
        base.vitesseX = 3.0F;
        base.vitesseY = 3.0F;
        base.posX = x;
        base.posY = y;
    }
}

