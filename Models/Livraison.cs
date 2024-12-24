using System;

namespace GestionCommandes.Models
{
    public class Livraison
    {
        public int Id { get; set; }
        public DateTime DateLivraison { get; set; }
        public string AdresseLivraison { get; set; }
        public int CommandeId { get; set; } // Clé étrangère vers Commande
    }
}
