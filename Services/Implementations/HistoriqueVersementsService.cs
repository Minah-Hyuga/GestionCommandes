using System.Collections.Generic;
using System.Linq;
using GestionCommandes.Models;

namespace GestionCommandes.Services.Implementations
{
    public class HistoriqueVersementsService : IHistoriqueVersementsService
    {
        private readonly GestionCommandesContext _context;

        public HistoriqueVersementsService(GestionCommandesContext context)
        {
            _context = context;
        }

        public IEnumerable<HistoriqueVersement> GetAllHistoriqueVersements()
        {
            return _context.HistoriquesVersements.ToList();
        }

        public HistoriqueVersement GetHistoriqueVersementById(int id)
        {
            return _context.HistoriquesVersements.Find(id);
        }

        public void AddHistoriqueVersement(HistoriqueVersement historiqueVersement)
        {
            _context.HistoriquesVersements.Add(historiqueVersement);
            _context.SaveChanges();
        }

        public void UpdateHistoriqueVersement(HistoriqueVersement historiqueVersement)
        {
            _context.HistoriquesVersements.Update(historiqueVersement);
            _context.SaveChanges();
        }

        public void DeleteHistoriqueVersement(int id)
        {
            var historiqueVersement = _context.HistoriquesVersements.Find(id);
            if (historiqueVersement != null)
            {
                _context.HistoriquesVersements.Remove(historiqueVersement);
                _context.SaveChanges();
            }
        }
    }
}
