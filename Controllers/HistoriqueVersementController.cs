// using Microsoft.AspNetCore.Mvc;
// using GestionCommandes.Models;
// using GestionCommandes.Services;
// using GestionCommandes.Controllers.implementations;

// namespace GestionCommandes.Controllers
// {
//     public class HistoriqueVersementController : Controller, IHistoriqueVersementsController
//     {
//         private readonly IHistoriqueVersementsService _historiqueVersementsService;

//         public HistoriqueVersementController(IHistoriqueVersementsService historiqueVersementsService)
//         {
//             _historiqueVersementsService = historiqueVersementsService;
//         }

//         public IActionResult Index()
//         {
//             var historiquesVersements = _historiqueVersementsService.GetAllHistoriqueVersements();
//             return View(historiquesVersements);
//         }

//         public IActionResult Create(HistoriqueVersement historiqueVersement)
//         {
//             if (ModelState.IsValid)
//             {
//                 _historiqueVersementsService.AddHistoriqueVersements(historiqueVersement);
//                 return RedirectToAction(nameof(Index));
//             }
//             return View(historiqueVersement);
//         }

//         public IActionResult Edit(int id)
//         {
//             var historiqueVersement = _historiqueVersementsService.GetHistoriqueVersementsById(id);
//             return View(historiqueVersement);
//         }

//         [HttpPost]
//         public IActionResult Edit(HistoriqueVersement historiqueVersement)
//         {
//             if (ModelState.IsValid)
//             {
//                 _historiqueVersementsService.UpdateHistoriqueVersements(historiqueVersement);
//                 return RedirectToAction(nameof(Index));
//             }
//             return View(historiqueVersement);
//         }

//         public IActionResult Delete(int id)
//         {
//             var historiqueVersement = _historiqueVersementsService.GetHistoriqueVersementsById(id);
//             return View(historiqueVersement);
//         }

//         [HttpPost, ActionName("Delete")]
//         public IActionResult DeleteConfirmed(int id)
//         {
//             _historiqueVersementsService.DeleteHistoriqueVersements(id);
//             return RedirectToAction(nameof(Index));
//         }
//     }
// }
