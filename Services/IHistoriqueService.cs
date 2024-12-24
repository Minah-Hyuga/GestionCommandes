using System.Collections.Generic;
using GestionCommandes.Models;

namespace GestionCommandes.Services
{
    public interface IHistoriqueService
    {
        IEnumerable<Historique> GetAllHistoriques();
        Historique GetHistoriqueById(int id);
        void AddHistorique(Historique historique);
        void UpdateHistorique(Historique historique);
        void DeleteHistorique(int id);
    }
}
