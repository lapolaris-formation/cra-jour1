using System.Security.Cryptography;
using System.Text;

// ATTENTION : code d'atelier (jour 4). La clé reste codée en dur : elle devrait
// venir de la configuration ou d'un coffre. Ne pas reprendre tel quel.
public class Chiffrement
{
    // Secret codé en dur : cible de la détection de secrets (étape 5)
    private const string ChaineConnexion =
        "Server=srv-prod-01;Database=Supervision;User Id=sa;Password=P@ssw0rd_Prod_2026;";

    // Clé de 256 bits codée en dur
    private static readonly byte[] Cle = Encoding.UTF8.GetBytes("12345678901234567890123456789012");

    private const int TailleSel = 16;
    private const int Iterations = 210_000;

    // PBKDF2 + SHA-256 + sel aléatoire, à la place de MD5
    public static string HacherMotDePasse(string motDePasse)
    {
        var sel = RandomNumberGenerator.GetBytes(TailleSel);
        var empreinte = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(motDePasse), sel, Iterations, HashAlgorithmName.SHA256, 32);

        // Le sel est stocké avec l'empreinte : il n'est pas secret
        return $"{Convert.ToHexString(sel)}:{Convert.ToHexString(empreinte)}";
    }

    // AES avec un IV aléatoire par message, à la place de DES avec IV fixe
    public static byte[] Chiffrer(string texte)
    {
        using var aes = Aes.Create();
        aes.Key = Cle;
        aes.GenerateIV();

        using var transformation = aes.CreateEncryptor();
        var octets = Encoding.UTF8.GetBytes(texte);
        var chiffre = transformation.TransformFinalBlock(octets, 0, octets.Length);

        // L'IV n'est pas secret, mais il doit accompagner le message pour déchiffrer
        return [.. aes.IV, .. chiffre];
    }

    // Méthode héritée, volontairement vulnérable : sert à vérifier que CodeQL
    // remonte bien un signalement dans l'onglet Security (atelier 9.2, étape 6).
    public static byte[] ChiffrerHerite(string texte)
    {
        using SymmetricAlgorithm des = new DESCryptoServiceProvider();
        des.Key = Encoding.UTF8.GetBytes("12345678");
        des.IV = Encoding.UTF8.GetBytes("87654321");

        using var transformation = des.CreateEncryptor();
        var octets = Encoding.UTF8.GetBytes(texte);
        return transformation.TransformFinalBlock(octets, 0, octets.Length);
    }

    public static string ObtenirChaineConnexion() => ChaineConnexion;
}
