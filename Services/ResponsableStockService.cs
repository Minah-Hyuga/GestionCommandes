using System.Collections.Generic;
using System.Linq;
using GestionCommandes.Models;

namespace GestionCommandes.Services.Implementations
{
    public class ResponsableStockService : IResponsableStockService
    {
        private readonly GestionCommandesContext _context;

        public ResponsableStockService(GestionCommandesContext context)
        {
            _context = context;
        }

        public IEnumerable<ResponsableStock> GetAllResponsableStocks()
        {
            return _context.ResponsablesStock.ToList();
        }

        public ResponsableStock GetResponsableStockById(int id)
        {
            return _context.ResponsablesStock.Find(id);
        }

        public void AddResponsableStock(ResponsableStock responsableStock)
        {
            _context.ResponsablesStock.Add(responsableStock);
            _context.SaveChanges();
        }

        public void UpdateResponsableStock(ResponsableStock responsableStock)
        {
            _context.ResponsablesStock.Update(responsableStock);
            _context.SaveChanges();
        }

        public void DeleteResponsableStock(int id)
        {
            var responsableStock = _context.ResponsablesStock.Find(id);
            if (responsableStock != null)
            {
                _context.ResponsablesStock.Remove(responsableStock);
                _context.SaveChanges();
            }
        }
    }
}
