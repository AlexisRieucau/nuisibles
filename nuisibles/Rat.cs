using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Rat : Nuisible
{
    /// <summary>
    /// Objet rat
    /// </summary>
    public Rat()
    {
        base.type = "rat";
        base.vitesseX = 2.0F;
        base.vitesseY = 2.0F;
    }
    /// <summary>
    /// Objet rat avec position d'apparition sur le terrain donnée
    /// </summary>
    /// <param name="x">position X</param>
    /// <param name="y">position Y</param>
    public Rat(float x, float y)
    {
        base.type = "rat";
        base.vitesseX = 2.0F;
        base.vitesseY = 2.0F;
        base.posX = x;
        base.posY = y;
    }
}
