public class Ligne
{
    public Produit Produit { get; }
    public int Quantite { get; }

    public Ligne(Produit produit, int quantite)
    {
        if (quantite <= 0) throw new ArgumentException("La quantite doit etre positive.");
        Produit = produit;
        Quantite = quantite;
    }
}