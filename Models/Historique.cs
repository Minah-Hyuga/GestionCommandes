using System;

namespace GestionCommandes.Models
{
    public class HistoriquePaiement
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; } = new Client();
        public string TypePaiement { get; set; } = string.Empty; // e.g., OM, Wave, Cheque
        public string ReferencePaiement { get; set; } = string.Empty;
        public decimal Montant { get; set; }
        public DateTime DatePaiement { get; set; }
    }
}
