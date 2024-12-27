using System;

namespace GestionCommandes.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public string Addresse { get; set; } = string.Empty;
        public decimal SoldeCompte { get; set; }
    }
}
