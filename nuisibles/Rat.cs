using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Rat : Nuisible
{
    public Rat()
    {
        base.type = "rat";
        base.vitesseX = 2.0F;
        base.vitesseY = 2.0F;
    }
    public Rat(float x, float y)
    {
        base.type = "rat";
        base.vitesseX = 2.0F;
        base.vitesseY = 2.0F;
        base.posX = x;
        base.posY = y;
    }
}
