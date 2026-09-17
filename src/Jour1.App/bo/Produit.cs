class Produit
{
    public string Reference { get; }
    public string Nom { get; }
    public double Prix { get; }

    public Produit(string reference, string nom, double prix)
    {
        Reference = reference;
        Nom = nom;
        Prix = prix;
    }
}