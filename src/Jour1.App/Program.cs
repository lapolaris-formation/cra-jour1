
Client client = new Client("Doe", "John", "doe.jhon@example.com");
Console.WriteLine($"Client : {client.Prenom} {client.Nom} ({client.Email})");
Ligne ligne1 = new Ligne(new Produit("REF-A", "Produit A", 10.0), 2);
Ligne ligne2 = new Ligne(new Produit("REF-B", "Produit B", 20.0), 1);
Panier panier = new Panier(client);
panier.AjouterLigne(ligne1);
panier.AjouterLigne(ligne2);
panier.AfficherPanier();
