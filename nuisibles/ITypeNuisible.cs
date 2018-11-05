using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

interface ITypeNuisible
{
    /// <summary>
    /// definit la maniere dont se deplace le nuisible en parametre
    /// </summary>
    /// <param name="nuisibles">liste des nuisibles presents dans la simulation</param>
    /// <param name="nuisible">nuisible donc on doit effectuer le deplacement</param>
    void Deplacement(List<Nuisible> nuisibles, Nuisible nuisible);
}
