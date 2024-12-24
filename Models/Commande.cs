using System;

namespace GestionCommandes.Models
{
    public class Commande
    {
        public int Id { get; set; }
        public DateTime DateCommande { get; set; }
        public decimal Montant { get; set; }
        public int ClientId { get; set; } // Clé étrangère vers Client
    }
}
