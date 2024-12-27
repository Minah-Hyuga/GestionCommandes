using System.Collections.Generic;
using System.Linq;
using GestionCommandes.Models;

namespace GestionCommandes.Services.Implementations
{
    public class LivreurService : ILivreurService
    {
        private readonly GestionCommandesContext _context;

        public LivreurService(GestionCommandesContext context)
        {
            _context = context;
        }

        public IEnumerable<Livreur> GetAllLivreurs()
        {
            return _context.Livreurs.ToList();
        }

        public Livreur GetLivreurById(int id)
        {
            return _context.Livreurs.Find(id);
        }

        public void AddLivreur(Livreur livreur)
        {
            _context.Livreurs.Add(livreur);
            _context.SaveChanges();
        }

        public void UpdateLivreur(Livreur livreur)
        {
            _context.Livreurs.Update(livreur);
            _context.SaveChanges();
        }

        public void DeleteLivreur(int id)
        {
            var livreur = _context.Livreurs.Find(id);
            if (livreur != null)
            {
                _context.Livreurs.Remove(livreur);
                _context.SaveChanges();
            }
        }
    }
}
