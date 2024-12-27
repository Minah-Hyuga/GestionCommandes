using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using GestionCommandes.Models;
using GestionCommandes.Services.Interfaces;

namespace GestionCommandes.Services.Implementations
{
    public class CommandeService : ICommandeService
    {
        private readonly GestionCommandesContext _context;
        private readonly ILogger<CommandeService> _logger;

        public CommandeService(GestionCommandesContext context, ILogger<CommandeService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<Commande>> GetAllCommandesAsync()
        {
            try
            {
                return await _context.Commandes
                    .AsNoTracking()
                    .Include(c => c.Client)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors de la récupération des commandes");
                throw;
            }
        }

        public async Task<Commande?> GetCommandeByIdAsync(int id)
        {
            try
            {
                return await _context.Commandes
                    .AsNoTracking()
                    .Include(c => c.ClientId)
                    .FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors de la récupération de la commande {CommandeId}", id);
                throw;
            }
        }

        public async Task<ServiceResult<Commande>> AddCommandeAsync(Commande commande)
        {
            if (commande == null)
            {
                return new ServiceResult<Commande>
                {
                    Success = false,
                    Message = "La commande ne peut pas être null"
                };
            }

            try
            {
                await _context.Commandes.AddAsync(commande);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Commande ajoutée avec succès. ID: {CommandeId}", commande.Id);

                return new ServiceResult<Commande>
                {
                    Success = true,
                    Data = commande,
                    Message = "Commande ajoutée avec succès"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors de l'ajout de la commande");
                return new ServiceResult<Commande>
                {
                    Success = false,
                    Message = "Une erreur est survenue lors de l'ajout de la commande"
                };
            }
        }

        public async Task<ServiceResult<Commande>> UpdateCommandeAsync(Commande commande)
        {
            if (commande == null)
            {
                return new ServiceResult<Commande>
                {
                    Success = false,
                    Message = "La commande ne peut pas être null"
                };
            }

            try
            {
                var existingCommande = await _context.Commandes
                    .FirstOrDefaultAsync(c => c.Id == commande.Id);

                if (existingCommande == null)
                {
                    return new ServiceResult<Commande>
                    {
                        Success = false,
                        Message = $"Commande avec l'ID {commande.Id} non trouvée"
                    };
                }

                _context.Entry(existingCommande).CurrentValues.SetValues(commande);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Commande mise à jour avec succès. ID: {CommandeId}", commande.Id);

                return new ServiceResult<Commande>
                {
                    Success = true,
                    Data = commande,
                    Message = "Commande mise à jour avec succès"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors de la mise à jour de la commande {CommandeId}", commande.Id);
                return new ServiceResult<Commande>
                {
                    Success = false,
                    Message = "Une erreur est survenue lors de la mise à jour de la commande"
                };
            }
        }

        public async Task<ServiceResult<bool>> DeleteCommandeAsync(int id)
        {
            try
            {
                var commande = await _context.Commandes.FindAsync(id);
                if (commande == null)
                {
                    return new ServiceResult<bool>
                    {
                        Success = false,
                        Message = $"Commande avec l'ID {id} non trouvée"
                    };
                }

                _context.Commandes.Remove(commande);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Commande supprimée avec succès. ID: {CommandeId}", id);

                return new ServiceResult<bool>
                {
                    Success = true,
                    Data = true,
                    Message = "Commande supprimée avec succès"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors de la suppression de la commande {CommandeId}", id);
                return new ServiceResult<bool>
                {
                    Success = false,
                    Message = "Une erreur est survenue lors de la suppression de la commande"
                };
            }
        }

        public async Task<bool> CommandeExistsAsync(int id)
        {
            return await _context.Commandes.AnyAsync(c => c.Id == id);
        }
    }
}