using Practica_calificada_2_Mjimenez.Models;
using Practica_calificada_2_Mjimenez.Repository;

namespace Practica_calificada_2_Mjimenez.Service;

public class ClientService: IClientService
{
   private readonly IUnitOfWork _unitOfWork;
   
   public ClientService(IUnitOfWork unitOfWork)
   {
       _unitOfWork = unitOfWork;
   }
   
   public async Task<IEnumerable<Client>> GetAllAsync()
   {
       return await _unitOfWork.Cliente.GetAllAsync();
   }
   
    public async Task<Client> GetByIdAsync(int id)
    {
         return await _unitOfWork.Cliente.GetByIdAsync(id);
    }
    
    public async Task<Client> CreateAsync(Client client)
    {
        await _unitOfWork.Cliente.AddAsync(client);
        await _unitOfWork.SaveAsync();
        return client;
    }
    
    public async Task<bool> UpdateAsync(int id, Client client)
    {
        var existing = await _unitOfWork.Cliente.GetByIdAsync(id);
        if (existing == null) return false;

        existing.Name = client.Name;
        existing.Email = client.Email;

        _unitOfWork.Cliente.Update(existing);
        await _unitOfWork.SaveAsync();

        return true;
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _unitOfWork.Cliente.GetByIdAsync(id);
        if (existing == null) return false;

        _unitOfWork.Cliente.Delete(existing);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<Client>> GetPorNombreAsync(string name)
    {
        //filtra clientes cuyo nombre contenga el parámetro
        return await _unitOfWork.Cliente.FindAsync(c => c.Name.Contains(name));
    }
    
    public async Task<Client> GetClientWithMostOrdersAsync()
    {
        var clients = await _unitOfWork.Cliente.GetAllAsync();
        return clients.OrderByDescending(c => c.Orders.Count).FirstOrDefault();
    }

    public async Task<IEnumerable<Client>> GetClientsBoughtSpecificProduct(int productId)
    {
        return await _unitOfWork.Cliente.GetClientsBoughtSpecificProductAsync(productId);
    }
}