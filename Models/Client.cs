using System;

namespace GestionCommandes.Models
{
    public class Client
    {
        public int Id { get; set; }
        public required string Nom { get; set; } = string.Empty; // Ensure initialization
        public required string Prenom { get; set; } = string.Empty; // Ensure initialization
        public required string Telephone { get; set; } = string.Empty; // Ensure initialization
        public required string Adresse { get; set; } = string.Empty; // Ensure initialization
        public decimal SoldeCompte { get; set; }
    }
}
