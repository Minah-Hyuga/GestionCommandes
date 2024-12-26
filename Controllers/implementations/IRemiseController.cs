using Microsoft.AspNetCore.Mvc;
using GestionCommandes.Models;

namespace GestionCommandes.Controllers.implementations
{
    public interface IRemiseController
    {
        IActionResult Index();
        IActionResult Create(Remise remise);
        IActionResult Edit(int id);
        IActionResult Delete(int id);
        IActionResult DeleteConfirmed(int id);
    }
}
