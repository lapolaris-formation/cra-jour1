class Client
{
    public string Nom { get; }
    public string Prenom { get; }
    public string Email { get; }

    public Client(string nom, string prenom, string email)
    {
        if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("L'email est obligatoire.");
        Nom = nom;
        Prenom = prenom;
        Email = email;
    }
}