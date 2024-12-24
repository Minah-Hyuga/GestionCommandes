using System;

namespace GestionCommandes.Models
{
    public class Comptable
{
    public int ComptableId { get; set; }  
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string Telephone { get; set; }
    public List<Commande> CommandesFacturees { get; set; }  

    public Comptable()
    {
        CommandesFacturees = new List<Commande>();
    }
}

}
