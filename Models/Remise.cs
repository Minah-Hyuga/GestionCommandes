using System;

namespace GestionCommandes.Models
{
    public class Remise
    {
        public int RemiseId { get; set; }  
        public required decimal Pourcentage { get; set; }  
        public required DateTime DateRemise { get; set; }
        public required int ClientId { get; set; } 
        public required Client Client { get; set; }  // Marked as required
    }
}
