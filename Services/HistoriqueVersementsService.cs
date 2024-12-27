// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.EntityFrameworkCore;
// using GestionCommandes.Models;

// namespace GestionCommandes.Services
// {
//     public interface IHistoriqueVersementsService
//     {
//         Task<IEnumerable<HistoriqueVersement>> GetAllHistoriqueVersementsAsync();
//         Task<HistoriqueVersement?> GetHistoriqueVersementByIdAsync(int id);
//         Task<bool> AddHistoriqueVersementAsync(HistoriqueVersement historiqueVersement);
//         Task<bool> UpdateHistoriqueVersementAsync(HistoriqueVersement historiqueVersement);
//         Task<bool> DeleteHistoriqueVersementAsync(int id);
//     }

//     public class HistoriqueVersementsService : IHistoriqueVersementsService
//     {
//         private readonly GestionCommandesContext _context;

//         public HistoriqueVersementsService(GestionCommandesContext context)
//         {
//             _context = context ?? throw new ArgumentNullException(nameof(context));
//         }

//         public async Task<IEnumerable<HistoriqueVersement>> GetAllHistoriqueVersementsAsync()
//         {
//             return await _context.HistoriquesVersements
//                 .AsNoTracking()
//                 .ToListAsync();
//         }

//         public async Task<HistoriqueVersement?> GetHistoriqueVersementByIdAsync(int id)
//         {
//             return await _context.HistoriquesVersements
//                 .AsNoTracking()
//                 .FirstOrDefaultAsync(h => h.Id == id);
//         }

//         public async Task<bool> AddHistoriqueVersementAsync(HistoriqueVersement historiqueVersement)
//         {
//             if (historiqueVersement == null)
//                 throw new ArgumentNullException(nameof(historiqueVersement));

//             try
//             {
//                 await _context.HistoriquesVersements.AddAsync(historiqueVersement);
//                 await _context.SaveChangesAsync();
//                 return true;
//             }
//             catch (Exception)
//             {
//                 return false;
//             }
//         }

//         public async Task<bool> UpdateHistoriqueVersementAsync(HistoriqueVersement historiqueVersement)
//         {
//             if (historiqueVersement == null)
//                 throw new ArgumentNullException(nameof(historiqueVersement));

//             try
//             {
//                 var existingVersement = await _context.HistoriquesVersements
//                     .FirstOrDefaultAsync(h => h.Id == historiqueVersement.Id);

//                 if (existingVersement == null)
//                     return false;

//                 _context.Entry(existingVersement).CurrentValues.SetValues(historiqueVersement);
//                 await _context.SaveChangesAsync();
//                 return true;
//             }
//             catch (Exception)
//             {
//                 return false;
//             }
//         }

//         public async Task<bool> DeleteHistoriqueVersementAsync(int id)
//         {
//             try
//             {
//                 var historiqueVersement = await _context.HistoriquesVersements
//                     .FirstOrDefaultAsync(h => h.Id == id);

//                 if (historiqueVersement == null)
//                     return false;

//                 _context.HistoriquesVersements.Remove(historiqueVersement);
//                 await _context.SaveChangesAsync();
//                 return true;
//             }
//             catch (Exception)
//             {
//                 return false;
//             }
//         }

//         public IEnumerable<HistoriqueVersement> GetAllHistoriqueVersements()
//         {
//             throw new NotImplementedException();
//         }

//         public HistoriqueVersement GetHistoriqueVersementById(int id)
//         {
//             throw new NotImplementedException();
//         }

//         public void AddHistoriqueVersement(HistoriqueVersement historiqueVersement)
//         {
//             throw new NotImplementedException();
//         }

//         public void UpdateHistoriqueVersement(HistoriqueVersement historiqueVersement)
//         {
//             throw new NotImplementedException();
//         }

//         public void DeleteHistoriqueVersement(int id)
//         {
//             throw new NotImplementedException();
//         }

//         public void AddHistoriqueVersements(HistoriqueVersement historiqueVersement)
//         {
//             throw new NotImplementedException();
//         }

//         public string? GetHistoriqueVersementsById(int id)
//         {
//             throw new NotImplementedException();
//         }

//         public void UpdateHistoriqueVersements(HistoriqueVersement historiqueVersement)
//         {
//             throw new NotImplementedException();
//         }

//         public void DeleteHistoriqueVersements(int id)
//         {
//             throw new NotImplementedException();
//         }
//     }
// }