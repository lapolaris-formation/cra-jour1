namespace Jour1.Tests;

public class PanierTests
{
    [Fact]
    public void Total_DeuxLignes_RetourneLaSomme()
    {
        // Arrange
        var client = new Client("Lovelace", "Ada", "ada@exemple.fr");
        var panier = new Panier(client);
        panier.AjouterLigne(new Ligne(new Produit("REF-1", "Clavier", 49.90, "Info", 10), 2));
        panier.AjouterLigne(new Ligne(new Produit("REF-2", "Souris", 20.20, "Info", 5), 1));

        // Act
        var total = panier.Total();

        // Assert
        Assert.Equal(120.0, total, 2);
    }

    [Theory]
    [InlineData(10.0, 1, 10.0)]
    [InlineData(10.0, 3, 30.0)]
    [InlineData(0.0, 5, 0.0)]
    [InlineData(19.99, 2, 39.98)]
    public void Total_UneLigne_MultiplieLePrixParLaQuantite(double prix, int quantite, double attendu)
    {
        var panier = new Panier(new Client("Lovelace", "Ada", "ada@exemple.fr"));
        panier.AjouterLigne(new Ligne(new Produit("REF-1", "Test", prix, "Info", 10), quantite));

        Assert.Equal(attendu, panier.Total(), 2);
    }

    [Fact]
    public void Ligne_QuantiteNulleOuNegative_LeveUneException()
    {
        var produit = new Produit("REF-1", "Clavier", 49.90, "Info", 10);

        Assert.Throws<ArgumentException>(() => new Ligne(produit, 0));
    }

    [Fact]
    public void Client_EmailSansArobase_LeveUneException()
    {
        Assert.Throws<ArgumentException>(() => new Client("Lovelace", "Ada", "ada-exemple.fr"));
    }

    [Fact]
    public void EstVide_PanierNeuf_RetourneVrai()
    {
        var panier = new Panier(new Client("Lovelace", "Ada", "ada@exemple.fr"));

        Assert.True(panier.EstVide());
    }

    [Fact]
    public void NombreLignes_ApresDeuxAjouts_RetourneDeux()
    {
        var panier = new Panier(new Client("Lovelace", "Ada", "ada@exemple.fr"));
        panier.AjouterLigne(new Ligne(new Produit("REF-1", "Clavier", 49.90, "Info", 10), 1));
        panier.AjouterLigne(new Ligne(new Produit("REF-2", "Souris", 20.20, "Info", 5), 1));

        Assert.Equal(2, panier.NombreLignes());
    }

    [Fact]
    public void AfficherPanier_AvecUneLigne_ListeLaLigneEtLeTotal()
    {
        var panier = new Panier(new Client("Lovelace", "Ada", "ada@exemple.fr"));
        panier.AjouterLigne(new Ligne(new Produit("REF-1", "Clavier", 49.90, "Info", 10), 2));

        var sortieOriginale = Console.Out;
        var ecrivain = new StringWriter();
        Console.SetOut(ecrivain);
        try
        {
            panier.AfficherPanier();
        }
        finally
        {
            Console.SetOut(sortieOriginale);
        }

        var texte = ecrivain.ToString();
        Assert.Contains("Clavier", texte);
        Assert.Contains("Ada", texte);
    }
}