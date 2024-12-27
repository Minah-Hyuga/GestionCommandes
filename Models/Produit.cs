using System;

namespace GestionCommandes.Models
{
    public class Produit
    {
        public int Id { get; set; }
        public required string Libellé { get; set; }
        public required int QuantitéStock { get; set; }
        public required decimal PrixUnitaire { get; set; }
        public required int QuantitéSeuil { get; set; }
    }
}
