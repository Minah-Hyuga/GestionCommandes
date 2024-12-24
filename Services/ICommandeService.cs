using System.Collections.Generic;
using GestionCommandes.Models;

namespace GestionCommandes.Services
{
    public interface ICommandeService
    {
        IEnumerable<Commande> GetAllCommandes();
        Commande GetCommandeById(int id);
        void AddCommande(Commande commande);
        void UpdateCommande(Commande commande);
        void DeleteCommande(int id);
    }
}
