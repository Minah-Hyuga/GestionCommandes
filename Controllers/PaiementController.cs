using Microsoft.AspNetCore.Mvc;
using GestionCommandes.Models;
using GestionCommandes.Services;
using GestionCommandes.Controllers.implementations;

namespace GestionCommandes.Controllers
{
    public class PaiementController : Controller, IPaiementController
    {
        private readonly IPaiementService _paiementService;

        public PaiementController(IPaiementService paiementService)
        {
            _paiementService = paiementService;
        }

        public IActionResult Index()
        {
            var paiements = _paiementService.GetAllPaiements();
            return View(paiements);
        }

        public IActionResult Create(Paiement paiement)
        {
            if (ModelState.IsValid)
            {
                _paiementService.AddPaiement(paiement);
                return RedirectToAction(nameof(Index));
            }
            return View(paiement);
        }

        public IActionResult Edit(int id)
        {
            var paiement = _paiementService.GetPaiementById(id);
            return View(paiement);
        }

        [HttpPost]
        public IActionResult Edit(Paiement paiement)
        {
            if (ModelState.IsValid)
            {
                _paiementService.UpdatePaiement(paiement);
                return RedirectToAction(nameof(Index));
            }
            return View(paiement);
        }

        public IActionResult Delete(int id)
        {
            var paiement = _paiementService.GetPaiementById(id);
            return View(paiement);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _paiementService.DeletePaiement(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
