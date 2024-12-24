using System;

namespace GestionCommandes.Models
{
    public class Paiement
    {
        public int Id { get; set; }
        public decimal Montant { get; set; }
        public string Type { get; set; } // chèque, carte, etc.
        public string Référence { get; set; }
        public int CommandeId { get; set; } // Clé étrangère vers Commande
    }
}
