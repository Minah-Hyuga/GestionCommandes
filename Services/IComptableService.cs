using System.Collections.Generic;
using GestionCommandes.Models;

namespace GestionCommandes.Services
{
    public interface IComptableService
    {
        IEnumerable<Comptable> GetAllComptables();
        Comptable GetComptableById(int id);
        void AddComptable(Comptable comptable);
        void UpdateComptable(Comptable comptable);
        void DeleteComptable(int id);
    }
}
