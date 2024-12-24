using System;
using System.ComponentModel.DataAnnotations;

namespace GestionCommandes.Models
{
    public class HistoriqueVersement
    {
        [Key]
        public int HistoriqueId { get; set; }  
        public DateTime DateAction { get; set; } 
        public string Action { get; set; }  
        public int CommandeId { get; set; }  
        public Commande Commande { get; set; }  
        public int ClientId { get; set; }  
        public Client Client { get; set; }  
        public int PaiementId { get; set; } 
        public Paiement Paiement { get; set; }  
    }
}
