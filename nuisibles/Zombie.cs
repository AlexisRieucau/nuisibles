using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Zombie : Nuisible
{
    /// <summary>
    /// Objet zombie
    /// </summary>
    public Zombie()
    {
        base.type = "zombie";
        base.vitesseX = 1.0F;
        base.vitesseY = 1.0F;
    }
    /// <summary>
    /// Objet zombie avec position d'apparition sur le terrain donnée
    /// </summary>
    /// <param name="x">position X</param>
    /// <param name="y">position Y</param>
    public Zombie(float x, float y)
    {
        base.type = "zombie";
        base.vitesseX = 1.0F;
        base.vitesseY = 1.0F;
        base.posX = x;
        base.posY = y;
    }
}

