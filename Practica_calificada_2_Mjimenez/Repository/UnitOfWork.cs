using Practica_calificada_2_Mjimenez.Models;

namespace Practica_calificada_2_Mjimenez.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    
    public IClientRepository Cliente { get; private set; }
    public IGenericRepository<Product> Productos { get; private set; }
    public IOrderRepository Order { get; private set; }
    public IGenericRepository<Orderdetail> Orderdetail { get; private set; }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        
        Cliente = new ClientRepository(_context);
        Productos = new GenericRepository<Product>(_context);
        Order = new OrderRepository(_context);
        Orderdetail = new GenericRepository<Orderdetail>(_context);
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}