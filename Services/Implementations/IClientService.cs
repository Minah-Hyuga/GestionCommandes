using System.Collections.Generic;
using GestionCommandes.Models;

namespace GestionCommandes.Services.Implementations
{
    public interface IClientService
    {
        IEnumerable<Client> GetAllClients();
        Client GetClientById(int id);
        void AddClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(int id);
    }
}
