using System.Collections.Generic;
using System.Linq;
using GestionCommandes.Models;

namespace GestionCommandes.Services.Implementations
{
    public class CommandeService : ICommandeService
    {
        private readonly GestionCommandesContext _context;

        public CommandeService(GestionCommandesContext context)
        {
            _context = context;
        }

        public IEnumerable<Commande> GetAllCommandes()
        {
            return _context.Commandes.ToList();
        }

        public Commande GetCommandeById(int id)
        {
            return _context.Commandes.Find(id);
        }

        public void AddCommande(Commande commande)
        {
            _context.Commandes.Add(commande);
            _context.SaveChanges();
        }

        public void UpdateCommande(Commande commande)
        {
            _context.Commandes.Update(commande);
            _context.SaveChanges();
        }

        public void DeleteCommande(int id)
        {
            var commande = _context.Commandes.Find(id);
            if (commande != null)
            {
                _context.Commandes.Remove(commande);
                _context.SaveChanges();
            }
        }
    }
}
