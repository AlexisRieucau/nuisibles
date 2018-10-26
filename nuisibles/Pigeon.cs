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
        base.vitesseX = 3;
        base.vitesseY = 3;
    }
}

