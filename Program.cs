using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GestionCommandes.Data;
using GestionCommandes.Services;
using GestionCommandes.Interfaces;

namespace GestionCommandes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    // Configuration de la base de données
                    services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseMySql(
                            hostContext.Configuration.GetConnectionString("DefaultConnection"), 
                            ServerVersion.AutoDetect(hostContext.Configuration.GetConnectionString("DefaultConnection"))
                        ));

                    // Enregistrement des services et interfaces
                    services.AddScoped<IClientService, ClientService>();
                    services.AddScoped<IClientService, ClientService>();
                    services.AddScoped<ICommandeService, CommandeService>();
                    services.AddScoped<IComptableService, ComptableService>();
                    services.AddScoped<IProduitService, ProduitService>();
                    services.AddScoped<IHistoriqueService, HistoriqueService>();
                    services.AddScoped<ILivraisonService, LivraisonService>();
                    services.AddScoped<IPaiementService, PaiementService>();
                    services.AddScoped<IResponsableStockService, ResponsableStockService>();
                    services.AddScoped<IComptableService, ComptableService>();
                    services.AddScoped<IRemiseService, RemiseService>();

                    // Ajout des contrôleurs et des vues
                    services.AddControllersWithViews();

                    // Optionnel: Ajouter les services de Razor Pages si nécessaire
                    services.AddRazorPages();
                });
    }
}