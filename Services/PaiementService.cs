
using System.Collections.Generic;
using System.Linq;
using GestionCommandes.Models;

namespace GestionCommandes.Services.Implementations
{
    public class PaiementService : IPaiementService
    {
        private readonly GestionCommandesContext _context;

        public PaiementService(GestionCommandesContext context)
        {
            _context = context;
        }

        public IEnumerable<Paiement> GetAllPaiements()
        {
            return _context.Paiements.ToList();
        }

        public Paiement GetPaiementById(int id)
        {
            return _context.Paiements.Find(id);
        }

        public void AddPaiement(Paiement paiement)
        {
            _context.Paiements.Add(paiement);
            _context.SaveChanges();
        }

        public void UpdatePaiement(Paiement paiement)
        {
            _context.Paiements.Update(paiement);
            _context.SaveChanges();
        }

        public void DeletePaiement(int id)
        {
            var paiement = _context.Paiements.Find(id);
            if (paiement != null)
            {
                _context.Paiements.Remove(paiement);
                _context.SaveChanges();
            }
        }
    }
}
