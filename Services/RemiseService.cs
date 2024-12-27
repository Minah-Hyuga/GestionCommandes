using System.Collections.Generic;
using System.Linq;
using GestionCommandes.Models;

namespace GestionCommandes.Services.Implementations
{
    public class RemiseService : IRemiseService
    {
        private readonly GestionCommandesContext _context;

        public RemiseService(GestionCommandesContext context)
        {
            _context = context;
        }

        public IEnumerable<Remise> GetAllRemises()
        {
            return _context.Remises.ToList();
        }

        public Remise GetRemiseById(int id)
        {
            return _context.Remises.Find(id);
        }

        public void AddRemise(Remise remise)
        {
            _context.Remises.Add(remise);
            _context.SaveChanges();
        }

        public void UpdateRemise(Remise remise)
        {
            _context.Remises.Update(remise);
            _context.SaveChanges();
        }

        public void DeleteRemise(int id)
        {
            var remise = _context.Remises.Find(id);
            if (remise != null)
            {
                _context.Remises.Remove(remise);
                _context.SaveChanges();
            }
        }
    }
}
