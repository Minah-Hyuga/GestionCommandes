using System;
using System.ComponentModel.DataAnnotations;

namespace GestionCommandes.Models
{
    public class HistoriqueVersement
    {
        [Key]
        public int HistoriqueId { get; set; }  
        public DateTime DateAction { get; set; } 
        public required string Action { get; set; } = string.Empty;  // Marked as required
        public int CommandeId { get; set; }  
        public required Commande Commande { get; set; }  // Marked as required
        public int ClientId { get; set; }  
        public required Client Client { get; set; }  // Marked as required
        public int PaiementId { get; set; } 
        public required Paiement Paiement { get; set; }  // Marked as required
        public int Id { get; internal set; }
    }
}
