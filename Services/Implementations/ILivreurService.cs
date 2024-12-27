using System.Collections.Generic;
using GestionCommandes.Models;

namespace GestionCommandes.Services
{
    public interface ILivreurService
    {
        IEnumerable<Livreur> GetAllLivreurs();
        Livreur GetLivreurById(int id);
        void AddLivreur(Livreur livreur);
        void UpdateLivreur(Livreur livreur);
        void DeleteLivreur(int id);
    }
}
