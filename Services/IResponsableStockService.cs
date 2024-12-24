using System.Collections.Generic;
using GestionCommandes.Models;

namespace GestionCommandes.Services
{
    public interface IResponsableStockService
    {
        IEnumerable<ResponsableStock> GetAllResponsableStocks();
        ResponsableStock GetResponsableStockById(int id);
        void AddResponsableStock(ResponsableStock responsableStock);
        void UpdateResponsableStock(ResponsableStock responsableStock);
        void DeleteResponsableStock(int id);
    }
}
