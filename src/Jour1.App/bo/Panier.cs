public class Panier{

    private List<Ligne> lignes;
    private Client client;

    public Panier(Client client){
        this.client = client;
        this.lignes = new List<Ligne>();
    }

    public void AjouterLigne(Ligne ligne){
        lignes.Add(ligne);
    }

    public bool EstVide(){
        return lignes.Count == 0;
    }

    public int NombreLignes(){
        return lignes.Count;
    }

    // calcul du total du panier
    public double Total(){
        return lignes.Sum(l => l.Produit.Prix);
    }



    public void AfficherPanier(){
        Console.WriteLine($"Panier de {client.Prenom} {client.Nom} :");
        foreach(var ligne in lignes){
            Console.WriteLine($"- {ligne.Produit.Nom} : {ligne.Produit.Prix} € (Quantité: {ligne.Quantite})");
        }
        Console.WriteLine($"Total : {Total()} €");
    }
}