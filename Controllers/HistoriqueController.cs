using Microsoft.AspNetCore.Mvc;
using GestionCommandes.Models;
using GestionCommandes.Services;
using GestionCommandes.Controllers.implementations;

namespace GestionCommandes.Controllers
{
    public class HistoriqueController : Controller, IHistoriqueController
    {
        private readonly IHistoriqueService _historiqueService;

        public HistoriqueController(IHistoriqueService historiqueService)
        {
            _historiqueService = historiqueService;
        }

        public IActionResult Index()
        {
            var historiques = _historiqueService.GetAllHistoriques();
            return View(historiques);
        }

        public IActionResult Create(Historique historique)
        {
            if (ModelState.IsValid)
            {
                _historiqueService.AddHistorique(historique);
                return RedirectToAction(nameof(Index));
            }
            return View(historique);
        }

        public IActionResult Edit(int id)
        {
            var historique = _historiqueService.GetHistoriqueById(id);
            return View(historique);
        }

        [HttpPost]
        public IActionResult Edit(Historique historique)
        {
            if (ModelState.IsValid)
            {
                _historiqueService.UpdateHistorique(historique);
                return RedirectToAction(nameof(Index));
            }
            return View(historique);
        }

        public IActionResult Delete(int id)
        {
            var historique = _historiqueService.GetHistoriqueById(id);
            return View(historique);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _historiqueService.DeleteHistorique(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
