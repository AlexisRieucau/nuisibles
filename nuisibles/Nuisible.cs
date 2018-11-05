using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class Nuisible
{
    public float posX;
    public float posY;
    public float posFuturX;
    public float posFuturY;
    public float vitesseX;
    public float vitesseY;
    public string type;
    public bool mort;
    public bool mutant;
    public bool passif;

    private Random rand = new Random();
    private readonly float critereDeCollision = 1.0F;

    public Nuisible()
    {
        posX = StaticRandom.tirage(0,500); // position x aleatoire sur le terrain
        posY = StaticRandom.tirage(0,500); // position y aleatoire sur le terrain
        mort = false;
        switch(StaticRandom.tirage(0,2)) // moitié de pigeons mutants
        {
            case 0:
                mutant = false;
                break;
            case 1:
                mutant = true;
                break;
        }
        if(StaticRandom.tirage(0,10) <= 8) // 20% de passifs
        {
            passif = false;
        }
        else
        {
            passif = true;
        }
    }

    /// <summary>
    /// deplacement du nuisible this
    /// </summary>
    /// <param name="nuisibles">liste des nuisibles dans l'ecosysteme</param>
    public void Deplacement(List<Nuisible> nuisibles)
    {
        List <ITypeNuisible> typeDeNuisible = new List<ITypeNuisible> { new NuisibleNormal(), new NuisiblePassif() };
        switch(this.passif)
        {
            case true:
                typeDeNuisible[1].Deplacement(nuisibles, this);
                break;
            case false:
                typeDeNuisible[0].Deplacement(nuisibles, this);
                break;
        }
    }

    /// <summary>
    /// vérifie la collision entre deux nuisibles (utilisation de pythagore pour obtenir la distance exacte entre les deux)
    /// </summary>
    /// <param name="nuisible">le nuisible a comparer pour la collision</param>
    /// <returns></returns>
    public bool Collision(Nuisible nuisible)
    {
        return Math.Sqrt(Math.Pow(this.posX - nuisible.posX,2) + Math.Pow(this.posY - nuisible.posY, 2)) <= critereDeCollision;
    }
}

/// <summary>
/// création d'une classe pour obtenir un random sans avoir à en créer un nouveau chaque fois qu'on doit tirer au sort => random sortait toujours le meme chiffre
/// </summary>
public static class StaticRandom
{
    private static Random rand = new Random();

    /// <summary>
    /// retourne un random dans l'intervalle donnée
    /// </summary>
    /// <param name="min">plus petit nombre a tirer au sort inclus</param>
    /// <param name="max">plus grand nombre a tirer au sort exclus</param>
    /// <returns></returns>
    public static int tirage(int min, int max) { return rand.Next(min, max); }
}
