using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using GestionCommandes.Models;
using GestionCommandes.Services.Interfaces;

namespace GestionCommandes.Services.Implementations
{
    public class ComptableService : IComptableService
    {
        private readonly GestionCommandesContext _context;
        private readonly ILogger<ComptableService> _logger;

        public ComptableService(GestionCommandesContext context, ILogger<ComptableService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<Comptable>> GetAllComptablesAsync()
        {
            try
            {
                return await _context.Comptables
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors de la récupération des comptables");
                throw;
            }
        }

        public async Task<Comptable?> GetComptableByIdAsync(int id)
        {
            try
            {
                return await _context.Comptables
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors de la récupération du comptable {ComptableId}", id);
                throw;
            }
        }

        public async Task<ServiceResult<Comptable>> AddComptableAsync(Comptable comptable)
        {
            if (comptable == null)
            {
                return new ServiceResult<Comptable>
                {
                    Success = false,
                    Message = "Le comptable ne peut pas être null"
                };
            }

            try
            {
                await _context.Comptables.AddAsync(comptable);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Comptable ajouté avec succès. ID: {ComptableId}", comptable.Id);

                return new ServiceResult<Comptable>
                {
                    Success = true,
                    Data = comptable,
                    Message = "Comptable ajouté avec succès"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors de l'ajout du comptable");
                return new ServiceResult<Comptable>
                {
                    Success = false,
                    Message = "Une erreur est survenue lors de l'ajout du comptable"
                };
            }
        }

        public async Task<ServiceResult<Comptable>> UpdateComptableAsync(Comptable comptable)
        {
            if (comptable == null)
            {
                return new ServiceResult<Comptable>
                {
                    Success = false,
                    Message = "Le comptable ne peut pas être null"
                };
            }

            try
            {
                var existingComptable = await _context.Comptables
                    .FirstOrDefaultAsync(c => c.Id == comptable.Id);

                if (existingComptable == null)
                {
                    return new ServiceResult<Comptable>
                    {
                        Success = false,
                        Message = $"Comptable avec l'ID {comptable.Id} non trouvé"
                    };
                }

                _context.Entry(existingComptable).CurrentValues.SetValues(comptable);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Comptable mis à jour avec succès. ID: {ComptableId}", comptable.Id);

                return new ServiceResult<Comptable>
                {
                    Success = true,
                    Data = comptable,
                    Message = "Comptable mis à jour avec succès"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors de la mise à jour du comptable {ComptableId}", comptable.Id);
                return new ServiceResult<Comptable>
                {
                    Success = false,
                    Message = "Une erreur est survenue lors de la mise à jour du comptable"
                };
            }
        }

        public async Task<ServiceResult<bool>> DeleteComptableAsync(int id)
        {
            try
            {
                var comptable = await _context.Comptables.FindAsync(id);
                if (comptable == null)
                {
                    return new ServiceResult<bool>
                    {
                        Success = false,
                        Message = $"Comptable avec l'ID {id} non trouvé"
                    };
                }

                _context.Comptables.Remove(comptable);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Comptable supprimé avec succès. ID: {ComptableId}", id);

                return new ServiceResult<bool>
                {
                    Success = true,
                    Data = true,
                    Message = "Comptable supprimé avec succès"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors de la suppression du comptable {ComptableId}", id);
                return new ServiceResult<bool>
                {
                    Success = false,
                    Message = "Une erreur est survenue lors de la suppression du comptable"
                };
            }
        }

        public async Task<bool> ComptableExistsAsync(int id)
        {
            return await _context.Comptables.AnyAsync(c => c.Id == id);
        }
    }
}