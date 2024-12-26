using Microsoft.AspNetCore.Mvc;
using GestionCommandes.Models;
using GestionCommandes.Services;
using GestionCommandes.Controllers.implementations;

namespace GestionCommandes.Controllers
{
    public class LivraisonController : Controller, ILivraisonController
    {
        private readonly ILivraisonService _livraisonService;

        public LivraisonController(ILivraisonService livraisonService)
        {
            _livraisonService = livraisonService;
        }

        public IActionResult Index()
        {
            var livraisons = _livraisonService.GetAllLivraisons();
            return View(livraisons);
        }

        public IActionResult Create(Livraison livraison)
        {
            if (ModelState.IsValid)
            {
                _livraisonService.AddLivraison(livraison);
                return RedirectToAction(nameof(Index));
            }
            return View(livraison);
        }

        public IActionResult Edit(int id)
        {
            var livraison = _livraisonService.GetLivraisonById(id);
            return View(livraison);
        }

        [HttpPost]
        public IActionResult Edit(Livraison livraison)
        {
            if (ModelState.IsValid)
            {
                _livraisonService.UpdateLivraison(livraison);
                return RedirectToAction(nameof(Index));
            }
            return View(livraison);
        }

        public IActionResult Delete(int id)
        {
            var livraison = _livraisonService.GetLivraisonById(id);
            return View(livraison);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _livraisonService.DeleteLivraison(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
