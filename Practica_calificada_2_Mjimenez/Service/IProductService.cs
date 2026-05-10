using Practica_calificada_2_Mjimenez.Models;

namespace Practica_calificada_2_Mjimenez.Service;

public interface IProductService
{
    Task<IEnumerable<Product>> GetProductsByPriceHigherThan(decimal price);
    
    Task<Product> GetHighestPricedProduct();

    Task<IAsyncResult> GetPriceAverage();
    
    Task<IEnumerable<Product>> GetProductsWithNoDescription();
}