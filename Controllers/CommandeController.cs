using Microsoft.AspNetCore.Mvc;
using GestionCommandes.Models;
using GestionCommandes.Services;

namespace GestionCommandes.Controllers
{
    public class CommandeController : Controller, implementations.ICommandeController
    {
        private readonly ICommandeService _commandeService;

        public CommandeController(ICommandeService commandeService)
        {
            _commandeService = commandeService;
        }

        public IActionResult Index()
        {
            var commandes = _commandeService.GetAllCommandes();
            return View(commandes);
        }

        public IActionResult Create(Commande commande)
        {
            if (ModelState.IsValid)
            {
                _commandeService.AddCommande(commande);
                return RedirectToAction(nameof(Index));
            }
            return View(commande);
        }

        public IActionResult Edit(int id)
        {
            var commande = _commandeService.GetCommandeById(id);
            return View(commande);
        }

        [HttpPost]
        public IActionResult Edit(Commande commande)
        {
            if (ModelState.IsValid)
            {
                _commandeService.UpdateCommande(commande);
                return RedirectToAction(nameof(Index));
            }
            return View(commande);
        }

        public IActionResult Delete(int id)
        {
            var commande = _commandeService.GetCommandeById(id);
            return View(commande);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _commandeService.DeleteCommande(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
