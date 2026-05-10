using Practica_calificada_2_Mjimenez.Models;

namespace Practica_calificada_2_Mjimenez.Service;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllOrdersAndDetails();
    Task<IEnumerable<Product>> GetProductsByClient(int clientId);
    Task<IEnumerable<Order>> GetOrdersAfterDate(DateTime date);
}