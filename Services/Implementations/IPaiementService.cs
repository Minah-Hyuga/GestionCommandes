using System.Collections.Generic;
using GestionCommandes.Models;

namespace GestionCommandes.Services
{
    public interface IPaiementService
    {
        IEnumerable<Paiement> GetAllPaiements();
        Paiement GetPaiementById(int id);
        void AddPaiement(Paiement paiement);
        void UpdatePaiement(Paiement paiement);
        void DeletePaiement(int id);
    }
}
