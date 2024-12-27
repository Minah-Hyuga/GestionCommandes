using System.Collections.Generic;
using System.Threading.Tasks;
using GestionCommandes.Models;

namespace GestionCommandes.Services.Interfaces
{
    public interface IComptableService
    {
        Task<IEnumerable<Comptable>> GetAllComptablesAsync();
        Task<Comptable?> GetComptableByIdAsync(int id);
        Task<ServiceResult<Comptable>> AddComptableAsync(Comptable comptable);
        Task<ServiceResult<Comptable>> UpdateComptableAsync(Comptable comptable);
        Task<ServiceResult<bool>> DeleteComptableAsync(int id);
        Task<bool> ComptableExistsAsync(int id);
    }
}