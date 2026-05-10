using Microsoft.EntityFrameworkCore;
using Practica_calificada_2_Mjimenez.Models;

namespace Practica_calificada_2_Mjimenez.Repository;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Order>> GetAllWithDetailsAsync()
    {
        return await _context.Orders
            .Include(o => o.Client)
            .Include(o => o.Orderdetails)
                .ThenInclude(od => od.Product)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsByClientAsync(int clientId)
    {
        return await _context.Orderdetails
            .Where(od => od.Order.ClientId == clientId)
            .Select(od => od.Product)
            .Distinct()
            .ToListAsync();
    }

    public async Task<IEnumerable<Order>> GetOrdersAfterDateAsync(DateTime date)
    {
        return await _context.Orders
            .Where(o => o.OrderDate > date)
            .Include(o => o.Client)
            .Include(o => o.Orderdetails)
                .ThenInclude(od => od.Product)
            .ToListAsync();
    }
}

