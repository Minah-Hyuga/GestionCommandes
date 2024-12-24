using System;

namespace GestionCommandes.Models
{
    public class Historique
    {
        public int Id { get; set; }
        public DateTime DateAction { get; set; }
        public string Description { get; set; }
        public int CommandeId { get; set; } // Clé étrangère vers Commande
    }
}
