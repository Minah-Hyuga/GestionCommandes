using System;

namespace GestionCommandes.Models
{
    public class Remise
{
    public int RemiseId { get; set; }  
    public decimal Pourcentage { get; set; }  
    public DateTime DateRemise { get; set; }
    public int ClientId { get; set; } 
    public Client Client { get; set; }  
}

}