class Produit
{
    public string Reference { get; }
    public string Nom { get; }
    public double Prix { get; }
    public string Categorie { get; }
    public int Stock { get; }



    public Produit(string reference, string nom, double prix, string categorie, int stock)
    {
        Reference = reference;
        Nom = nom;
        Prix = prix;
        Categorie = categorie;
        Stock = stock;
    }
}