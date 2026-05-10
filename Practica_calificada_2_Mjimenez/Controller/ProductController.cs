using Microsoft.AspNetCore.Mvc;
using Practica_calificada_2_Mjimenez.Service;

namespace Practica_calificada_2_Mjimenez.Controller;

[ApiController]
[Route("api/[controller]")]
public class ProductController:ControllerBase
{
    private readonly IProductService _productService;
    
    public ProductController(IProductService productService)
    {
        _productService = productService;
    
    }
    
    //get api/product/price/100
    [HttpGet("price/{price}")]
    public async Task<IActionResult> GetListByPriceHigherThan(decimal price) {
        return Ok(await _productService.GetProductsByPriceHigherThan(price));
    }
    
    //get api/product/highest
    [HttpGet("highest")]
    public async Task<IActionResult> GetHighestPricedProduct() {
        return Ok(await _productService.GetHighestPricedProduct());
    }
    
    //get api/product/average
    [HttpGet("average")]
    public async Task<IActionResult> GetPriceAverage() {
        return Ok(await _productService.GetPriceAverage());
    }
    
    //get api/product/nodescription
    [HttpGet("nodescription")]
    public async Task<IActionResult> GetProductsWithNoDescription() {
        return Ok(await _productService.GetProductsWithNoDescription());
    }
}
