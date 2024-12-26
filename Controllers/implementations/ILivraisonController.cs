using Microsoft.AspNetCore.Mvc;
using GestionCommandes.Models;

namespace GestionCommandes.Controllers.implementations
{
    public interface ILivraisonController
    {
        IActionResult Index();
        IActionResult Create(Livraison livraison);
        IActionResult Edit(int id);
        IActionResult Delete(int id);
        IActionResult DeleteConfirmed(int id);
    }
}
