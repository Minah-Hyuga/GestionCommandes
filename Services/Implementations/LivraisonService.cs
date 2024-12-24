using System.Collections.Generic;
using System.Linq;
using GestionCommandes.Models;

namespace GestionCommandes.Services.Implementations
{
    public class LivraisonService : ILivraisonService
    {
        private readonly GestionCommandesContext _context;

        public LivraisonService(GestionCommandesContext context)
        {
            _context = context;
        }

        public IEnumerable<Livraison> GetAllLivraisons()
        {
            return _context.Livraisons.ToList();
        }

        public Livraison GetLivraisonById(int id)
        {
            return _context.Livraisons.Find(id);
        }

        public void AddLivraison(Livraison livraison)
        {
            _context.Livraisons.Add(livraison);
            _context.SaveChanges();
        }

        public void UpdateLivraison(Livraison livraison)
        {
            _context.Livraisons.Update(livraison);
            _context.SaveChanges();
        }

        public void DeleteLivraison(int id)
        {
            var livraison = _context.Livraisons.Find(id);
            if (livraison != null)
            {
                _context.Livraisons.Remove(livraison);
                _context.SaveChanges();
            }
        }
    }
}
