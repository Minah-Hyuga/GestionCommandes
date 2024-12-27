using System;

namespace GestionCommandes.Models
{
    public class Historique
    {
        public int Id { get; set; }
        public DateTime DateAction { get; set; }
        public required string Description { get; set; } = string.Empty; // Marked as required
        public int CommandeId { get; set; } // Clé étrangère vers Commande
    }
}
