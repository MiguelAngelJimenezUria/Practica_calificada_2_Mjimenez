using Microsoft.EntityFrameworkCore;
using Practica_calificada_2_Mjimenez.Models;

namespace Practica_calificada_2_Mjimenez.Repository;

public class ClientRepository : GenericRepository<Client>, IClientRepository
{
    public ClientRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Client>> GetClientsBoughtSpecificProductAsync(int productId)
    {
        return await _context.Clients
            .Where(c => c.Orders.Any(o => o.Orderdetails.Any(od => od.ProductId == productId)))
            .ToListAsync();
    }
}

