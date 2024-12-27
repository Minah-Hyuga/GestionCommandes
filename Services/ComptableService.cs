// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using GestionCommandes.Data;
// using GestionCommandes.Models;
// using Microsoft.EntityFrameworkCore;

// namespace GestionCommandes.Services.Implementations
// {
//     public class ComptableService : IComptableService
//     {
//         private readonly ApplicationDbContext _context;

//         public ComptableService(ApplicationDbContext context)
//         {
//             _context = context;
//         }

//         // Récupérer tous les comptables
//         public async Task<IEnumerable<Comptable>> GetAllComptablesAsync()
//         {
//             return await _context.Comptables.ToListAsync();
//         }

//         // Récupérer un comptable par son ID
//         public async Task<Comptable?> GetComptableByIdAsync(int id)
//         {
//             return await _context.Comptables.FirstOrDefaultAsync(c => c.Id == id);
//         }

//         // Ajouter un nouveau comptable
//         public async Task<ServiceResult<Comptable>> AddComptableAsync(Comptable comptable)
//         {
//             var result = new ServiceResult<Comptable>();
            
//             try
//             {
//                 _context.Comptables.Add(comptable);
//                 await _context.SaveChangesAsync();
//                 result.Data = comptable;
//                 result.Success = true;
//             }
//             catch (Exception ex)
//             {
//                 result.Success = false;
//                 result.Message = $"Erreur: {ex.Message}";
//             }
            
//             return result;
//         }

//         // Mettre à jour un comptable
//         public async Task<ServiceResult<Comptable>> UpdateComptableAsync(Comptable comptable)
//         {
//             var result = new ServiceResult<Comptable>();
            
//             try
//             {
//                 _context.Comptables.Update(comptable);
//                 await _context.SaveChangesAsync();
//                 result.Data = comptable;
//                 result.Success = true;
//             }
//             catch (Exception ex)
//             {
//                 result.Success = false;
//                 result.Message = $"Erreur: {ex.Message}";
//             }
            
//             return result;
//         }

//         // Supprimer un comptable
//         public async Task<ServiceResult<bool>> DeleteComptableAsync(int id)
//         {
//             var result = new ServiceResult<bool>();
            
//             try
//             {
//                 var comptable = await _context.Comptables.FindAsync(id);
//                 if (comptable == null)
//                 {
//                     result.Success = false;
//                     result.Message = "Comptable introuvable";
//                     return result;
//                 }

//                 _context.Comptables.Remove(comptable);
//                 await _context.SaveChangesAsync();
//                 result.Data = true;
//                 result.Success = true;
//             }
//             catch (Exception ex)
//             {
//                 result.Success = false;
//                 result.Message = $"Erreur: {ex.Message}";
//             }
            
//             return result;
//         }

//         // Vérifier si un comptable existe
//         public async Task<bool> ComptableExistsAsync(int id)
//         {
//             return await _context.Comptables.AnyAsync(c => c.Id == id);
//         }
//     }

//     public class ServiceResult<T>
//     {
//         public Comptable Data { get; internal set; }
//         public bool Success { get; internal set; }
//         public string Message { get; internal set; }
//     }

//     public interface IComptableService
//     {
//         Task<string?> GetAllComptablesAsync();
//     }
// }
