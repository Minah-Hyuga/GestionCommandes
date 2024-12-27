using Microsoft.AspNetCore.Mvc;
using GestionCommandes.Models;

namespace GestionCommandes.Controllers.implementations
{
    public interface ICommandeController
    {
        Task<IActionResult> Index();
        Task<IActionResult> Create(Commande commande);
        Task<IActionResult> Edit(int id);
        Task<IActionResult> Delete(int id);
        Task<IActionResult> DeleteConfirmed(int id);
    }
}
