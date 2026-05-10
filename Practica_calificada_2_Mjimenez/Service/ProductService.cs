using Practica_calificada_2_Mjimenez.Models;
using Practica_calificada_2_Mjimenez.Repository;

namespace Practica_calificada_2_Mjimenez.Service;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Product>> GetProductsByPriceHigherThan(decimal price)
    {
        return await _unitOfWork.Productos.FindAsync(p => p.Price > price);
    }
    
    public async Task<Product> GetHighestPricedProduct()
    {
        var products = await _unitOfWork.Productos.GetAllAsync();
        return products.OrderByDescending(p => p.Price).FirstOrDefault();
    }

    public async Task<IAsyncResult> GetPriceAverage()
    {
        var products = await _unitOfWork.Productos.GetAllAsync();
        var average = products.Average(p => p.Price);
        return Task.FromResult(average);
    }
    
    public async Task<IEnumerable<Product>> GetProductsWithNoDescription()
    {
        return await _unitOfWork.Productos.FindAsync(p => string.IsNullOrEmpty(p.Description));
    }
}