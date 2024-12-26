using Microsoft.AspNetCore.Mvc;
using GestionCommandes.Models;
using GestionCommandes.Services;

namespace GestionCommandes.Controllers
{
    public class ComptableController : Controller, IComptableController
    {
        private readonly IComptableService _comptableService;

        public ComptableController(IComptableService comptableService)
        {
            _comptableService = comptableService;
        }

        public IActionResult Index()
        {
            var comptables = _comptableService.GetAllComptables();
            return View(comptables);
        }

        public IActionResult Create(Comptable comptable)
        {
            if (ModelState.IsValid)
            {
                _comptableService.AddComptable(comptable);
                return RedirectToAction(nameof(Index));
            }
            return View(comptable);
        }

        public IActionResult Edit(int id)
        {
            var comptable = _comptableService.GetComptableById(id);
            return View(comptable);
        }

        [HttpPost]
        public IActionResult Edit(Comptable comptable)
        {
            if (ModelState.IsValid)
            {
                _comptableService.UpdateComptable(comptable);
                return RedirectToAction(nameof(Index));
            }
            return View(comptable);
        }

        public IActionResult Delete(int id)
        {
            var comptable = _comptableService.GetComptableById(id);
            return View(comptable);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _comptableService.DeleteComptable(id);
            return RedirectToAction(nameof(Index));
        }
    }

    internal interface IComptableController
    {
    }
}
