using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GestionCommandes.Data;
using GestionCommandes.Services;
using GestionCommandes.Services.Implementations;
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.EntityFrameworkCore;

namespace GestionCommandes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Création de l'hôte et exécution de l'application
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // Configuration de l'hôte web
                    webBuilder.UseStartup<Startup>(); // Assurez-vous que vous avez un fichier Startup.cs
                })
                .ConfigureServices((context, services) =>
                {
                    // Configuration des services nécessaires à l'application

                    // Configuration de la base de données avec MySQL
                    services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseMySql(
                            context.Configuration.GetConnectionString("DefaultConnection"),
                            ServerVersion.AutoDetect(context.Configuration.GetConnectionString("DefaultConnection"))
                        ));

                    // Enregistrement des services (Injection de dépendances)
                    services.AddScoped<IClientService, ClientService>();
                    services.AddScoped<ICommandeService, CommandeService>();
                    services.AddScoped<IComptableService, ComptableService>();
                    services.AddScoped<IProduitService, ProduitService>();
                    services.AddScoped<IHistoriqueService, HistoriqueService>();
                    services.AddScoped<ILivraisonService, LivraisonService>();
                    services.AddScoped<IPaiementService, PaiementService>();
                    services.AddScoped<IResponsableStockService, ResponsableStockService>();
                    services.AddScoped<IRemiseService, RemiseService>();
                    services.AddScoped<ILivreurService, LivreurService>();
                    services.AddScoped<IHistoriqueVersementsService, HistoriqueVersementsService>();

                    // Ajout des contrôleurs et des vues
                    services.AddControllersWithViews();

                    // Ajout de Razor Pages si nécessaire
                    services.AddRazorPages();
                });
    }
}
