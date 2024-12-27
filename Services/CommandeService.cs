using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using GestionCommandes.Models;

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

        #region Méthodes publiques

        public async Task<IEnumerable<Commande>> GetAllCommandesAsync()
        {
            try
            {
                _logger.LogInformation("Récupération de toutes les commandes.");
                return await _context.Commandes
                    .AsNoTracking()
                    .Include(c => c.Client)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors de la récupération des commandes.");
                throw new ServiceException("Erreur lors de la récupération des commandes.", ex);
            }
        }

        public async Task<Commande?> GetCommandeByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("Récupération de la commande avec ID {Id}.", id);
                return await _context.Commandes
                    .AsNoTracking()
                    .Include(c => c.Client)
                    .FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors de la récupération de la commande avec ID {Id}.", id);
                throw new ServiceException($"Erreur lors de la récupération de la commande avec ID {id}.", ex);
            }
        }

        public async Task<ServiceResult<Commande>> AddCommandeAsync(Commande commande)
        {
            if (commande == null)
            {
                return ServiceResult<Commande>.Error("La commande ne peut pas être null.");
            }

            try
            {
                await _context.Commandes.AddAsync(commande);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Commande ajoutée avec succès. ID: {CommandeId}.", commande.Id);
                return ServiceResult<Commande>.Success(commande, "Commande ajoutée avec succès.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors de l'ajout de la commande.");
                return ServiceResult<Commande>.Error("Une erreur est survenue lors de l'ajout de la commande.");
            }
        }

        public async Task<ServiceResult<Commande>> UpdateCommandeAsync(Commande commande)
        {
            if (commande == null)
            {
                return ServiceResult<Commande>.Error("La commande ne peut pas être null.");
            }

            try
            {
                var existingCommande = await _context.Commandes.FindAsync(commande.Id);
                if (existingCommande == null)
                {
                    return ServiceResult<Commande>.Error($"Commande avec l'ID {commande.Id} non trouvée.");
                }

                UpdateCommandeDetails(existingCommande, commande);

                await _context.SaveChangesAsync();

                _logger.LogInformation("Commande mise à jour avec succès. ID: {CommandeId}.", commande.Id);
                return ServiceResult<Commande>.Success(existingCommande, "Commande mise à jour avec succès.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors de la mise à jour de la commande avec ID {CommandeId}.", commande.Id);
                return ServiceResult<Commande>.Error("Une erreur est survenue lors de la mise à jour de la commande.");
            }
        }

        public async Task<ServiceResult<bool>> DeleteCommandeAsync(int id)
        {
            try
            {
                var commande = await _context.Commandes.FindAsync(id);
                if (commande == null)
                {
                    return ServiceResult<bool>.Error($"Commande avec l'ID {id} non trouvée.");
                }

                _context.Commandes.Remove(commande);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Commande supprimée avec succès. ID: {CommandeId}.", id);
                return ServiceResult<bool>.Success(true, "Commande supprimée avec succès.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors de la suppression de la commande avec ID {CommandeId}.", id);
                return ServiceResult<bool>.Error("Une erreur est survenue lors de la suppression de la commande.");
            }
        }

        public async Task<bool> CommandeExistsAsync(int id)
        {
            try
            {
                return await _context.Commandes.AsNoTracking().AnyAsync(c => c.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors de la vérification de l'existence de la commande avec ID {CommandeId}.", id);
                throw new ServiceException($"Erreur lors de la vérification de l'existence de la commande avec ID {id}.", ex);
            }
        }

        #endregion

        #region Méthodes privées

        private void UpdateCommandeDetails(Commande existingCommande, Commande newCommande)
        {
            existingCommande.ClientId = newCommande.ClientId;
            existingCommande.Montant = newCommande.Montant;
            existingCommande.Produit = newCommande.Produit;
        }

        #endregion

        [Serializable]
        internal class ServiceException : Exception
        {
            public ServiceException() { }

            public ServiceException(string? message) : base(message) { }

            public ServiceException(string? message, Exception? innerException) : base(message, innerException) { }
        }
    }
}
