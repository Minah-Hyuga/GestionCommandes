using System.Collections.Generic;
using System.Linq;
using GestionCommandes.Models;

namespace GestionCommandes.Services.Implementations
{
    public class ClientService : IClientService
    {
        private readonly GestionCommandesContext _context;

        public ClientService(GestionCommandesContext context)
        {
            _context = context;
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _context.Clients.ToList();
        }

        public Client GetClientById(int id)
        {
            return _context.Clients.Find(id);
        }

        public void AddClient(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        public void UpdateClient(Client client)
        {
            _context.Clients.Update(client);
            _context.SaveChanges();
        }

        public void DeleteClient(int id)
        {
            var client = _context.Clients.Find(id);
            if (client != null)
            {
                _context.Clients.Remove(client);
                _context.SaveChanges();
            }
        }
    }
}
