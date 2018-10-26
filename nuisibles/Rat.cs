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
        base.vitesseX = 2;
        base.vitesseY = 2;
    }
}
