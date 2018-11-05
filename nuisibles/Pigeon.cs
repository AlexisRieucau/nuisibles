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
        base.vitesseX = Constantes.vitessePigeon;
        base.vitesseY = Constantes.vitessePigeon;
    }
    /// <summary>
    /// Objet pigeon avec position d'apparition sur le terrain donnée
    /// </summary>
    /// <param name="x">position X</param>
    /// <param name="y">position Y</param>
    public Pigeon(float x, float y)
    {
        base.type = "pigeon";
        base.vitesseX = Constantes.vitessePigeon;
        base.vitesseY = Constantes.vitessePigeon;
        base.posX = x;
        base.posY = y;
    }
}

