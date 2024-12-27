using Microsoft.AspNetCore.Mvc;
using GestionCommandes.Models;
using GestionCommandes.Services.Interfaces;
using GestionCommandes.Services;

namespace GestionCommandes.Controllers
{
    public class CommandeController : Controller, implementations.ICommandeController
    {
        private readonly ICommandeService _commandeService;
        private readonly IClientService _clientService; // Added client service

        public CommandeController(ICommandeService commandeService, IClientService clientService)
        {
            _commandeService = commandeService;
            _clientService = clientService; // Initialize client service
        }

        public async Task<IActionResult> Index()
        {
            var commandes = await _commandeService.GetAllCommandesAsync();
            return View(commandes);
        }

        public async Task<IActionResult> Create(Commande commande)
        {
            ViewBag.Clients = await _clientService.GetAllClientsAsync(); // Populate ViewBag.Clients
            if (ModelState.IsValid)
            {
                await _commandeService.AddCommandeAsync(commande);
                return RedirectToAction(nameof(Index));
            }
            return View(commande);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var commande = await _commandeService.GetCommandeByIdAsync(id);
            ViewBag.Clients = await _clientService.GetAllClientsAsync(); // Populate ViewBag.Clients
            return View(commande);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Commande commande)
        {
            if (ModelState.IsValid)
            {
                await _commandeService.UpdateCommandeAsync(commande);
                return RedirectToAction(nameof(Index));
            }
            return View(commande);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var commande = await _commandeService.GetCommandeByIdAsync(id);
            return View(commande);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _commandeService.DeleteCommandeAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
