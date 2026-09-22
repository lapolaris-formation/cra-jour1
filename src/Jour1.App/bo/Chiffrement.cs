using System.Security.Cryptography;
using System.Text;

// ATTENTION : code volontairement vulnérable, atelier 9.2 du jour 4.
// Ne jamais reprendre ce fichier dans un produit réel.
public class Chiffrement
{
    // Secret codé en dur : cible de la détection de secrets (étape 5)
    private const string ChaineConnexion =
        "Server=srv-prod-01;Database=Supervision;User Id=sa;Password=P@ssw0rd_Prod_2026;"; 

    // Clé et vecteur d'initialisation codés en dur
    private static readonly byte[] Cle = Encoding.UTF8.GetBytes("12345678");
    private static readonly byte[] Iv = Encoding.UTF8.GetBytes("87654321");

    // Hachage avec un algorithme cassé : attendu CA5351
    public static string HacherMotDePasse(string motDePasse)
    {
        using var md5 = MD5.Create();
        var empreinte = md5.ComputeHash(Encoding.UTF8.GetBytes(motDePasse));
        return Convert.ToHexString(empreinte);
    }

    // Chiffrement avec un algorithme cassé : attendu CA5351 et cs/weak-encryption
    public static byte[] Chiffrer(string texte)
    {
        using SymmetricAlgorithm des = new DESCryptoServiceProvider();
        des.Key = Cle;
        des.IV = Iv;

        using var transformation = des.CreateEncryptor();
        var octets = Encoding.UTF8.GetBytes(texte);
        return transformation.TransformFinalBlock(octets, 0, octets.Length);
    }

    public static string ObtenirChaineConnexion() => ChaineConnexion;
}
