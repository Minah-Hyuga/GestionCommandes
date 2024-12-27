using System;

namespace GestionCommandes.Models
{
    public class Livraison
    {
        public int Id { get; set; }
        public DateTime DateLivraison { get; set; }
        public required string AdresseLivraison { get; set; } = string.Empty; // Marked as required
        public int CommandeId { get; set; } // Clé étrangère vers Commande
    }
}
