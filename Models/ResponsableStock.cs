using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionCommandes.Models
{
    public class ResponsableStock
    {
        [Key]
        public int RsId { get; set; }  
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Telephone { get; set; }
        public List<Commande> CommandesPreparees { get; set; }  

        public ResponsableStock()
        {
            CommandesPreparees = new List<Commande>();
        }
    }
}
