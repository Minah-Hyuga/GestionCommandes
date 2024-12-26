using Microsoft.AspNetCore.Mvc;
using GestionCommandes.Models;
using GestionCommandes.Services;
using GestionCommandes.Controllers.implementations;

namespace GestionCommandes.Controllers
{
    public class RemiseController : Controller, IRemiseController
    {
        private readonly IRemiseService _remiseService;

        public RemiseController(IRemiseService remiseService)
        {
            _remiseService = remiseService;
        }

        public IActionResult Index()
        {
            var remises = _remiseService.GetAllRemises();
            return View(remises);
        }

        public IActionResult Create(Remise remise)
        {
            if (ModelState.IsValid)
            {
                _remiseService.AddRemise(remise);
                return RedirectToAction(nameof(Index));
            }
            return View(remise);
        }

        public IActionResult Edit(int id)
        {
            var remise = _remiseService.GetRemiseById(id);
            return View(remise);
        }

        [HttpPost]
        public IActionResult Edit(Remise remise)
        {
            if (ModelState.IsValid)
            {
                _remiseService.UpdateRemise(remise);
                return RedirectToAction(nameof(Index));
            }
            return View(remise);
        }

        public IActionResult Delete(int id)
        {
            var remise = _remiseService.GetRemiseById(id);
            return View(remise);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _remiseService.DeleteRemise(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
