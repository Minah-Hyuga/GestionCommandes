using System.Collections.Generic;
using GestionCommandes.Models;

namespace GestionCommandes.Services
{
    public interface ILivraisonService
    {
        IEnumerable<Livraison> GetAllLivraisons();
        Livraison GetLivraisonById(int id);
        void AddLivraison(Livraison livraison);
        void UpdateLivraison(Livraison livraison);
        void DeleteLivraison(int id);
    }
}
