using Microsoft.AspNetCore.Mvc;
using GestionCommandes.Models;
using GestionCommandes.Services;
using GestionCommandes.Controllers.implementations;

namespace GestionCommandes.Controllers
{
    public class LivreurController : Controller, ILivreurController
    {
        private readonly ILivreurService _livreurService;

        public LivreurController(ILivreurService livreurService)
        {
            _livreurService = livreurService;
        }

        public IActionResult Index()
        {
            var livreurs = _livreurService.GetAllLivreurs();
            return View(livreurs);
        }

        public IActionResult Create(Livreur livreur)
        {
            if (ModelState.IsValid)
            {
                _livreurService.AddLivreur(livreur);
                return RedirectToAction(nameof(Index));
            }
            return View(livreur);
        }

        public IActionResult Edit(int id)
        {
            var livreur = _livreurService.GetLivreurById(id);
            return View(livreur);
        }

        [HttpPost]
        public IActionResult Edit(Livreur livreur)
        {
            if (ModelState.IsValid)
            {
                _livreurService.UpdateLivreur(livreur);
                return RedirectToAction(nameof(Index));
            }
            return View(livreur);
        }

        public IActionResult Delete(int id)
        {
            var livreur = _livreurService.GetLivreurById(id);
            return View(livreur);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _livreurService.DeleteLivreur(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
