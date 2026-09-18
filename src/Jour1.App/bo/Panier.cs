class Panier{
    private List<Ligne> lignes;
    private Client client;

    public Panier(Client client){
        this.client = client;
        this.lignes = new List<Ligne>();
    }

    public void AjouterLigne(Ligne ligne){
        lignes.Add(ligne);
    }

    public int NombreLignes(){
        return lignes.Count;
    }

    public void AfficherPanier(){
        Console.WriteLine($"Panier de {client.Prenom} {client.Nom} :");
        foreach(var ligne in lignes){
            Console.WriteLine($"- {ligne.Produit.Nom} : ${ligne.Produit.Prix} (Quantité: {ligne.Quantite})");
        }
    }
}