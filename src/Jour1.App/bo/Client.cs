class Client
{
    public string Nom { get; }
    public string Prenom { get; }
    public string Email { get; }

    public Client(string nom, string prenom, string email)
    {
        Nom = nom;
        Prenom = prenom;
        Email = email;
    }
}