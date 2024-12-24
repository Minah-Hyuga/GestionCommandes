using System;

namespace GestionCommandes.Models
{
    public class Produit
    {
        public int Id { get; set; }
        public string Libellé { get; set; }
        public int QuantitéStock { get; set; }
        public decimal PrixUnitaire { get; set; }
        public int QuantitéSeuil { get; set; }
    }
}
