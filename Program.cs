using Microsoft.EntityFrameworkCore;
using GestionCommandes.Data;
using GestionCommandes.Services; // Use the correct namespace for the services
using GestionCommandes.Services;
using GestionCommandes.Models;

var builder = WebApplication.CreateBuilder(args);

// Services de base
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

// Base de données
builder.Services.AddDbContext<GestionCommandesContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));

// Injection des services
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<ICommandeService, CommandeService>();
builder.Services.AddScoped<IComptableService, ComptableService>();
builder.Services.AddScoped<IProduitService, ProduitService>();
// builder.Services.AddScoped<IHistoriqueService, HistoriqueService>();
builder.Services.AddScoped<ILivraisonService, LivraisonService>();
builder.Services.AddScoped<IPaiementService, PaiementService>();
builder.Services.AddScoped<IResponsableStockService, ResponsableStockService>();
builder.Services.AddScoped<IRemiseService, RemiseService>();
builder.Services.AddScoped<ILivreurService, LivreurService>();

var app = builder.Build();

// Configuration de l'application
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();