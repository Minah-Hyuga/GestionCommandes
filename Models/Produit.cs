using System;

namespace GestionCommandes.Models
{
    public class Produit
    {
        public int Id { get; set; }
        public string Libelle { get; set; } = string.Empty;
        public int QuantiteEnStock { get; set; }
        public decimal PrixUnitaire { get; set; }
        public int QuantiteSeuil { get; set; }
        public string Images { get; set; } = string.Empty;
    }
}
