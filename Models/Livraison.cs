using System;

namespace GestionCommandes.Models
{
    public class Livraison
    {
        public int Id { get; set; }
        public DateTime DateLivraison { get; set; }
        public string AdresseLivraison { get; set; } = string.Empty;
        public int CommandeId { get; set; }
        public Commande Commande { get; set; } = new Commande();
        public int LivreurId { get; set; }
        public Livreur Livreur { get; set; } = new Livreur();
    }
}
