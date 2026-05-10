using Practica_calificada_2_Mjimenez.Models;
using Practica_calificada_2_Mjimenez.Repository;

namespace Practica_calificada_2_Mjimenez.Service;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAndDetails()
    {
        return await _unitOfWork.Order.GetAllWithDetailsAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsByClient(int clientId)
    {
        return await _unitOfWork.Order.GetProductsByClientAsync(clientId);
    }

    public async Task<IEnumerable<Order>> GetOrdersAfterDate(DateTime date)
    {
        return await _unitOfWork.Order.GetOrdersAfterDateAsync(date);
    }
}