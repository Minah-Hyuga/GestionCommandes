using Microsoft.AspNetCore.Mvc;
using GestionCommandes.Models;

namespace GestionCommandes.Controllers.implementations
{
    public interface IComptableController
    {
        Task<IActionResult> Index();
        Task<IActionResult> Create(Comptable comptable);
        Task<IActionResult> Edit(int id);
        Task<IActionResult> Delete(int id);
        Task<IActionResult> DeleteConfirmed(int id);
    }
}
