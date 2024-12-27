using System;

namespace GestionCommandes.Models
{
    public class Commande
    {
        public int Id { get; set; }
        public DateTime DateCommande { get; set; }
        public decimal Montant { get; set; }
        public int ClientId { get; set; } // Clé étrangère vers Client
        public required Client Client { get; set; } = new Client { Nom = string.Empty, Prenom = string.Empty, Telephone = string.Empty, Adresse = string.Empty }; // Marked as required and initialized

    public static implicit operator bool(Commande v)
        {
            throw new NotImplementedException();
        }
    }
}
