class Client
{
    public string Nom { get; }
    public string Prenom { get; }
    public string Email { get; }

    public Client(string nom, string prenom, string email)
    {
        if (string.IsNullOrWhiteSpace(email) || !email.Contains('@')) throw new ArgumentException("L'adresse email du client est invalide.");
        Nom = nom;
        Prenom = prenom;
        Email = email;
    }
}