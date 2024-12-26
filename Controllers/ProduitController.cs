using Microsoft.AspNetCore.Mvc;
using GestionCommandes.Models;
using GestionCommandes.Services;
using GestionCommandes.Controllers.implementations;
using GestionCommandes.Services.Implementations;

namespace GestionCommandes.Controllers
{
    public class ProduitController : Controller, IProduitController
    {
        private readonly IProduitService _produitService;

        public ProduitController(IProduitService produitService)
        {
            _produitService = produitService;
        }

        public IActionResult Index()
        {
            var produits = _produitService.GetAllProduits();
            return View(produits);
        }

        public IActionResult Create(Produit produit)
        {
            if (ModelState.IsValid)
            {
                _produitService.AddProduit(produit);
                return RedirectToAction(nameof(Index));
            }
            return View(produit);
        }

        public IActionResult Edit(int id)
        {
            var produit = _produitService.GetProduitById(id);
            return View(produit);
        }

        [HttpPost]
        public IActionResult Edit(Produit produit)
        {
            if (ModelState.IsValid)
            {
                _produitService.UpdateProduit(produit);
                return RedirectToAction(nameof(Index));
            }
            return View(produit);
        }

        public IActionResult Delete(int id)
        {
            var produit = _produitService.GetProduitById(id);
            return View(produit);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _produitService.DeleteProduit(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
