using Practica_calificada_2_Mjimenez.Models;

namespace Practica_calificada_2_Mjimenez.Repository;

public interface IUnitOfWork: IDisposable
{
    IClientRepository Cliente { get; }
    IOrderRepository Order { get; }
    IGenericRepository<Orderdetail> Orderdetail { get; }
    IGenericRepository<Product> Productos { get; }
    
    Task<int> SaveAsync();
}