using Practica_calificada_2_Mjimenez.Models;

namespace Practica_calificada_2_Mjimenez.Service;

public interface IClientService
{
    Task<IEnumerable<Client>> GetAllAsync();
    Task<Client> GetByIdAsync(int id);
    Task<Client> CreateAsync(Client client);
    Task<bool> UpdateAsync(int id, Client client);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<Client>> GetPorNombreAsync(string name);
    
    Task<Client> GetClientWithMostOrdersAsync();
    Task<IEnumerable<Client>> GetClientsBoughtSpecificProduct(int productId);
}