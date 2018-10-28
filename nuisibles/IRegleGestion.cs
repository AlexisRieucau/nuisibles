using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

interface IRegleGestion
{
    List<Nuisible> Regles(List<Nuisible> nuisibles, Nuisible nuisible);
}