using Microsoft.EntityFrameworkCore;
using GestionCommandes.Models;

namespace GestionCommandes.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Paiement> Paiements { get; set; }
        public DbSet<Livraison> Livraisons { get; set; }
        // public DbSet<Historique> Historiques { get; set; }
        public DbSet<ResponsableStock> ResponsablesStock { get; set; }
        public DbSet<Remise> Remises { get; set; }
        public DbSet<HistoriqueVersement> HistoriqueVersements { get; set; }
        public DbSet<Livreur> Livreurs { get; set; }
        public DbSet<Comptable> Comptables { get; set; }
    }
}
