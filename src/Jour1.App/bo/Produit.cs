class Produit
{
    public string Nom { get; }
    public double Prix { get; }

    public Produit(string nom, double prix)
    {
        Nom = nom;
        Prix = prix;
    }
}