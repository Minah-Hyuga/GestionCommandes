using System;
using System.ComponentModel.DataAnnotations;

namespace GestionCommandes.Models
{
public class Livreur
{
    public int LivreurId { get; set; }  
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string Telephone { get; set; }
    public List<Livraison> Livraisons { get; set; }  
    public Livreur()
    {
        Livraisons = new List<Livraison>();
    }
}

}
