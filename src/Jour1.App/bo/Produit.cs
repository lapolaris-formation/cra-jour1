class Produit
{
    public string Reference { get; }
    public string Nom { get; }
    public double Prix { get; }
    public string Categorie { get; }


    public Produit(string reference, string nom, double prix, string categorie)
    {
        Reference = reference;
        Nom = nom;
        Prix = prix;
        Categorie = categorie;
    }
}