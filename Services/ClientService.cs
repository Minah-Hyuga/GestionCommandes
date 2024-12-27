using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GestionCommandes.Models;
using Microsoft.Extensions.Logging;

namespace GestionCommandes.Services
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetAllClientsAsync();
        Task<Client?> GetClientByIdAsync(int id);
        Task<Result<Client>> AddClientAsync(Client client);
        Task<Result<Client>> UpdateClientAsync(Client client);
        Task<Result<bool>> DeleteClientAsync(int id);
        Task<bool> ClientExistsAsync(int id);
    }

    public class Result<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }

    public class ClientService : IClientService

    {
        private readonly GestionCommandesContext _context;
        private readonly ILogger<ClientService> _logger;

        public ClientService(GestionCommandesContext context, ILogger<ClientService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            try
            {
                return await _context.Clients
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors de la récupération de tous les clients");
                throw;
            }
        }

        public async Task<Client?> GetClientByIdAsync(int id)
        {
            try
            {
                return await _context.Clients
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors de la récupération du client avec l'ID {ClientId}", id);
                throw;
            }
        }

        public async Task<Result<Client>> AddClientAsync(Client client)
        {
            if (client == null)
            {
                return new Result<Client>
                {
                    Success = false,
                    Message = "Le client ne peut pas être null"
                };
            }

            try
            {
                await _context.Clients.AddAsync(client);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Client ajouté avec succès. ID: {ClientId}", client.Id);

                return new Result<Client>
                {
                    Success = true,
                    Data = client,
                    Message = "Client ajouté avec succès"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors de l'ajout du client");
                return new Result<Client>
                {
                    Success = false,
                    Message = "Une erreur est survenue lors de l'ajout du client"
                };
            }
        }

        public async Task<Result<Client>> UpdateClientAsync(Client client)
        {
            if (client == null)
            {
                return new Result<Client>
                {
                    Success = false,
                    Message = "Le client ne peut pas être null"
                };
            }

            try
            {
                var existingClient = await _context.Clients
                    .FirstOrDefaultAsync(c => c.Id == client.Id);

                if (existingClient == null)
                {
                    return new Result<Client>
                    {
                        Success = false,
                        Message = $"Client avec l'ID {client.Id} non trouvé"
                    };
                }

                _context.Entry(existingClient).CurrentValues.SetValues(client);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Client mis à jour avec succès. ID: {ClientId}", client.Id);

                return new Result<Client>
                {
                    Success = true,
                    Data = client,
                    Message = "Client mis à jour avec succès"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors de la mise à jour du client avec l'ID {ClientId}", client.Id);
                return new Result<Client>
                {
                    Success = false,
                    Message = "Une erreur est survenue lors de la mise à jour du client"
                };
            }
        }

        public async Task<Result<bool>> DeleteClientAsync(int id)
        {
            try
            {
                var client = await _context.Clients.FindAsync(id);
                if (client == null)
                {
                    return new Result<bool>
                    {
                        Success = false,
                        Message = $"Client avec l'ID {id} non trouvé"
                    };
                }

                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Client supprimé avec succès. ID: {ClientId}", id);

                return new Result<bool>
                {
                    Success = true,
                    Data = true,
                    Message = "Client supprimé avec succès"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors de la suppression du client avec l'ID {ClientId}", id);
                return new Result<bool>
                {
                    Success = false,
                    Message = "Une erreur est survenue lors de la suppression du client"
                };
            }
        }

        public async Task<bool> ClientExistsAsync(int id)
        {
            return await _context.Clients.AnyAsync(c => c.Id == id);
        }

        public IEnumerable<Client> GetAllClients()
        {
            throw new NotImplementedException();
        }

        public Client GetClientById(int id)
        {
            throw new NotImplementedException();
        }

        public void AddClient(Client client)
        {
            throw new NotImplementedException();
        }

        public void UpdateClient(Client client)
        {
            throw new NotImplementedException();
        }

        public void DeleteClient(int id)
        {
            throw new NotImplementedException();
        }
    }
}