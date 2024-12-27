using System.Collections.Generic;
using System.Threading.Tasks;
using GestionCommandes.Models;

namespace GestionCommandes.Adapters.Interfaces
{
    public interface ICommandeAdapter
    {
        Commande ConvertToCommande(CommandeInputModel commandeInput);
        CommandeOutputModel ConvertToCommandeOutput(Commande commande);
        IEnumerable<CommandeOutputModel> ConvertToCommandeOutputList(IEnumerable<Commande> commandes);
        Task<System.ComponentModel.DataAnnotations.ValidationResult> ValidateCommandeInputAsync(CommandeInputModel commandeInput);
    }

    public class CommandeOutputModel
    {
        public int Id { get; set; }
        public string NomClient { get; set; }
        public DateTime DateCommande { get; set; }
        public decimal Montant { get; set; }
        public List<string> Produits { get; set; } = new List<string>();
    }
    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }

    public class CommandeInputModel
    {
        public int ClientId { get; set; }
        public DateTime DateCommande { get; set; }
        public decimal Montant { get; set; }
        public List<int> ProduitsIds { get; set; } = new List<int>();
    }

}
