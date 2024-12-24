using System;

namespace GestionCommandes.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prénom { get; set; }
        public string Téléphone { get; set; }
        public string Adresse { get; set; }
        public decimal SoldeCompte { get; set; }
    }
}
