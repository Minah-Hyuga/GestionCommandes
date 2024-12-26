using Microsoft.AspNetCore.Mvc;
using GestionCommandes.Models;

namespace GestionCommandes.Controllers.implementations
{
    public interface IProduitController
    {
        IActionResult Index();
        IActionResult Create(Produit produit);
        IActionResult Edit(int id);
        IActionResult Delete(int id);
        IActionResult DeleteConfirmed(int id);
    }
}
