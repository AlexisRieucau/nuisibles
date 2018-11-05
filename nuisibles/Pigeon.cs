using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Pigeon : Nuisible
{
    /// <summary>
    /// Objet pigeon
    /// </summary>
    public Pigeon()
    {
        base.type = "pigeon";
        base.vitesseX = 3.0F;
        base.vitesseY = 3.0F;
    }
    /// <summary>
    /// Objet pigeon avec position d'apparition sur le terrain donnée
    /// </summary>
    /// <param name="x">position X</param>
    /// <param name="y">position Y</param>
    public Pigeon(float x, float y)
    {
        base.type = "pigeon";
        base.vitesseX = 3.0F;
        base.vitesseY = 3.0F;
        base.posX = x;
        base.posY = y;
    }
}

