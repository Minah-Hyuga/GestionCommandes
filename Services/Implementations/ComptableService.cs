using System.Collections.Generic;
using System.Linq;
using GestionCommandes.Models;

namespace GestionCommandes.Services.Implementations
{
    public class ComptableService : IComptableService
    {
        private readonly GestionCommandesContext _context;

        public ComptableService(GestionCommandesContext context)
        {
            _context = context;
        }

        public IEnumerable<Comptable> GetAllComptables()
        {
            return _context.Comptables.ToList();
        }

        public Comptable GetComptableById(int id)
        {
            return _context.Comptables.Find(id);
        }

        public void AddComptable(Comptable comptable)
        {
            _context.Comptables.Add(comptable);
            _context.SaveChanges();
        }

        public void UpdateComptable(Comptable comptable)
        {
            _context.Comptables.Update(comptable);
            _context.SaveChanges();
        }

        public void DeleteComptable(int id)
        {
            var comptable = _context.Comptables.Find(id);
            if (comptable != null)
            {
                _context.Comptables.Remove(comptable);
                _context.SaveChanges();
            }
        }
    }
}
