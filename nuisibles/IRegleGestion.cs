using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

interface IRegleGestion
{
    /// <summary>
    /// définit le comportement des nuisibles de la simulation en fonction de la regle choisie
    /// </summary>
    /// <param name="nuisibles">la liste des nuisibles présents dans l'ecosysteme</param>
    /// <param name="nuisible">le nuisible actuellement analysé dans la simulation</param>
    /// <returns></returns>
    List<Nuisible> Regles(List<Nuisible> nuisibles, Nuisible nuisible);
}