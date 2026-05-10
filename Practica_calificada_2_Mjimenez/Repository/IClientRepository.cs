using Practica_calificada_2_Mjimenez.Models;

namespace Practica_calificada_2_Mjimenez.Repository;

public interface IClientRepository : IGenericRepository<Client>
{
    Task<IEnumerable<Client>> GetClientsBoughtSpecificProductAsync(int productId);
}

