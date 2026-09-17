class Ligne
{
    public Produit Produit { get; }
    public int Quantite { get; }

    public Ligne(Produit produit, int quantite)
    {
        Produit = produit;
        Quantite = quantite;
    }
}