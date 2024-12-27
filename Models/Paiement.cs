using System;

namespace GestionCommandes.Models
{
    public class Paiement
    {
        public int Id { get; set; }
        public decimal Montant { get; set; }
        public required string Type { get; set; } = string.Empty; // chèque, carte, etc.
        public required string Référence { get; set; } = string.Empty; // Ensure initialization
        public int CommandeId { get; set; } // Clé étrangère vers Commande
        public DateTime DatePaiement { get; internal set; }
    }
}
