// using System.Collections.Generic;
// using System.Linq;
// using GestionCommandes.Models;

// namespace GestionCommandes.Services.Implementations
// {
//     public class HistoriqueService : IHistoriqueService
//     {
//         private readonly GestionCommandesContext _context;

//         public HistoriqueService(GestionCommandesContext context)
//         {
//             _context = context;
//         }

//         public IEnumerable<Historique> GetAllHistoriques()
//         {
//             return _context.Historiques.ToList();
//         }

//         public Historique GetHistoriqueById(int id)
//         {
//             return _context.Historiques.Find(id);
//         }

//         public void AddHistorique(Historique historique)
//         {
//             _context.Historiques.Add(historique);
//             _context.SaveChanges();
//         }

//         public void UpdateHistorique(Historique historique)
//         {
//             _context.Historiques.Update(historique);
//             _context.SaveChanges();
//         }

//         public void DeleteHistorique(int id)
//         {
//             var historique = _context.Historiques.Find(id);
//             if (historique != null)
//             {
//                 _context.Historiques.Remove(historique);
//                 _context.SaveChanges();
//             }
//         }
//     }
// }
