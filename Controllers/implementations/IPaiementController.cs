using Microsoft.AspNetCore.Mvc;
using GestionCommandes.Models;

namespace GestionCommandes.Controllers.implementations
{
    public interface IPaiementController
    {
        IActionResult Index();
        IActionResult Create(Paiement paiement);
        IActionResult Edit(int id);
        IActionResult Delete(int id);
        IActionResult DeleteConfirmed(int id);
    }
}
