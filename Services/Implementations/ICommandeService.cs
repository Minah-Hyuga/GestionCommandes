using System.Collections.Generic;
using System.Threading.Tasks;
using GestionCommandes.Models;

namespace GestionCommandes.Services.Implementations
{
    public interface ICommandeService
    {
        Task<IEnumerable<Commande>> GetAllCommandesAsync();
        Task<Commande?> GetCommandeByIdAsync(int id);
        Task<ServiceResult<Commande>> AddCommandeAsync(Commande commande);
        Task<ServiceResult<Commande>> UpdateCommandeAsync(Commande commande);
        Task<ServiceResult<bool>> DeleteCommandeAsync(int id);
        Task<bool> CommandeExistsAsync(int id);
    }
}
