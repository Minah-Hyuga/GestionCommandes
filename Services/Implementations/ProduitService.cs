using System.Collections.Generic;
using System.Linq;
using GestionCommandes.Models;

namespace GestionCommandes.Services.Implementations
{
    public class ProduitService : IProduitService
    {
        private readonly GestionCommandesContext _context;

        public ProduitService(GestionCommandesContext context)
        {
            _context = context;
        }

        public IEnumerable<Produit> GetAllProduits()
        {
            return _context.Produits.ToList();
        }

        public Produit GetProduitById(int id)
        {
            return _context.Produits.Find(id);
        }

        public void AddProduit(Produit produit)
        {
            _context.Produits.Add(produit);
            _context.SaveChanges();
        }

        public void UpdateProduit(Produit produit)
        {
            _context.Produits.Update(produit);
            _context.SaveChanges();
        }

        public void DeleteProduit(int id)
        {
            var produit = _context.Produits.Find(id);
            if (produit != null)
            {
                _context.Produits.Remove(produit);
                _context.SaveChanges();
            }
        }
    }

    public interface IProduitService
    {
        void AddProduit(Produit produit);
        void DeleteProduit(int id);
        string? GetAllProduits();
        string? GetProduitById(int id);
        void UpdateProduit(Produit produit);
    }
}
