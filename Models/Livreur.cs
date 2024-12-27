using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace GestionCommandes.Models
{
    public class Livreur
    {
        public int LivreurId { get; set; }  
        public required string Nom { get; set; } = string.Empty; // Ensure initialization
        public required string Prenom { get; set; } = string.Empty; // Ensure initialization
        public required string Telephone { get; set; } = string.Empty; // Ensure initialization
        public List<Livraison> Livraisons { get; set; }  

        public Livreur()
        {
            Livraisons = new List<Livraison>();
        }
    }
}
