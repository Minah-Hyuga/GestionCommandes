using System.Collections.Generic;
using GestionCommandes.Models;

namespace GestionCommandes.Services
{
    public interface IHistoriqueVersementsService
    {
        IEnumerable<HistoriqueVersement> GetAllHistoriqueVersements();
        HistoriqueVersement GetHistoriqueVersementById(int id);
        void AddHistoriqueVersement(HistoriqueVersement historiqueVersement);
        void UpdateHistoriqueVersement(HistoriqueVersement historiqueVersement);
        void DeleteHistoriqueVersement(int id);
    }
}
