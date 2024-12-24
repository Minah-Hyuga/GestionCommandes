using System.Collections.Generic;
using GestionCommandes.Models;

namespace GestionCommandes.Services
{
    public interface IRemiseService
    {
        IEnumerable<Remise> GetAllRemises();
        Remise GetRemiseById(int id);
        void AddRemise(Remise remise);
        void UpdateRemise(Remise remise);
        void DeleteRemise(int id);
    }
}
