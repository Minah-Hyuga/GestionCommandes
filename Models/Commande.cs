using System;
using System.Collections.Generic;

namespace GestionCommandes.Models
{
    public class Commande
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Montant { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; } = new Client();
        public List<Produit> Produit { get; set; } = new List<Produit>();
    }
}
