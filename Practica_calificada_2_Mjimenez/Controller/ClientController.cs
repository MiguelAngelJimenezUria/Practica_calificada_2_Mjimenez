using Microsoft.AspNetCore.Mvc;
using Practica_calificada_2_Mjimenez.Service;

namespace Practica_calificada_2_Mjimenez.Controller;

[ApiController]
[Route("api/[controller]")]
public class ClientController:ControllerBase
{
    private readonly IClientService _clientService;
     
    
    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }
    
    
    //get  api/client
    [HttpGet]
    public async Task<IActionResult> Get() {
        return Ok(await _clientService.GetAllAsync());
    }
    
    //get api/client/nombre
    [HttpGet("{nombre}")]
    public async Task<IActionResult> GetListByName(string nombre) {
        return Ok(await _clientService.GetPorNombreAsync(nombre));
    }
    
    // GET api/client/product/5
    [HttpGet("product/{productId:int}")]
    public async Task<IActionResult> GetClientsByProduct(int productId) {
        return Ok(await _clientService.GetClientsBoughtSpecificProduct(productId));
    }
    
    // GET api/client/mostorders
    [HttpGet("mostorders")]
    public async Task<IActionResult> GetClientWithMostOrders() {
        return Ok(await _clientService.GetClientWithMostOrdersAsync());
    }
    
}