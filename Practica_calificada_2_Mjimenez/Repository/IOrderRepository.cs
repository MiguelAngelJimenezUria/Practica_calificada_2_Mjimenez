using Practica_calificada_2_Mjimenez.Models;

namespace Practica_calificada_2_Mjimenez.Repository;

public interface IOrderRepository : IGenericRepository<Order>
{
    Task<IEnumerable<Order>> GetAllWithDetailsAsync();
    Task<IEnumerable<Product>> GetProductsByClientAsync(int clientId);
    Task<IEnumerable<Order>> GetOrdersAfterDateAsync(DateTime date);
}

