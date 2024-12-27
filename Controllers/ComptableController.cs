using Microsoft.AspNetCore.Mvc;
using GestionCommandes.Models;
using GestionCommandes.Services.Interfaces;
using GestionCommandes.Controllers.implementations;

namespace GestionCommandes.Controllers
{
    public class ComptableController : Controller, IComptableController
    {
        private readonly IComptableService _comptableService;

        public ComptableController(IComptableService comptableService)
        {
            _comptableService = comptableService;
        }

        public async Task<IActionResult> Index()
        {
            var comptables = await _comptableService.GetAllComptablesAsync();
            return View(comptables);
        }

        public async Task<IActionResult> Create(Comptable comptable)
        {
            if (ModelState.IsValid)
            {
                await _comptableService.AddComptableAsync(comptable);
                return RedirectToAction(nameof(Index));
            }
            return View(comptable);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var comptable = await _comptableService.GetComptableByIdAsync(id);
            return View(comptable);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Comptable comptable)
        {
            if (ModelState.IsValid)
            {
                await _comptableService.UpdateComptableAsync(comptable);
                return RedirectToAction(nameof(Index));
            }
            return View(comptable);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var comptable = await _comptableService.GetComptableByIdAsync(id);
            return View(comptable);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _comptableService.DeleteComptableAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
