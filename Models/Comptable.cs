using System;

namespace GestionCommandes.Models
{
    public class Comptable
    {
        public int ComptableId { get; set; }  
        public required string Nom { get; set; } = string.Empty; // Ensure initialization
        public required string Prenom { get; set; } = string.Empty; // Ensure initialization
        public required string Telephone { get; set; } = string.Empty; // Ensure initialization
        public List<Commande> CommandesFacturees { get; set; }  
        public int Id { get; internal set; }

        public Comptable()
        {
            CommandesFacturees = new List<Commande>();
        }

        public static implicit operator bool(Comptable v)
        {
            throw new NotImplementedException();
        }

        public static implicit operator Comptable(bool v)
        {
            throw new NotImplementedException();
        }
    }
}
