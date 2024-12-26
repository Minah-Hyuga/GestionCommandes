using Microsoft.AspNetCore.Mvc;
using GestionCommandes.Models;

namespace GestionCommandes.Controllers.implementations
{
    public interface ILivreurController
    {
        IActionResult Index();
        IActionResult Create(Livreur livreur);
        IActionResult Edit(int id);
        IActionResult Delete(int id);
        IActionResult DeleteConfirmed(int id);
    }
}
