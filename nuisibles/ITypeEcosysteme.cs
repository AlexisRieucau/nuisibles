using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

interface ITypeEcosysteme
{
    /// <summary>
    /// rempli l'ecosysteme avec certains types de nuisibles en fonction du type choisi
    /// </summary>
    /// <param name="nuisibles">liste des nuisibles présents dans l'ecosysteme</param>
    void Peupler(List<Nuisible> nuisibles);
}
