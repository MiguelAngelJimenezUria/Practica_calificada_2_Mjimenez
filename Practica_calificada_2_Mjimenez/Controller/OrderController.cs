using Microsoft.AspNetCore.Mvc;
using Practica_calificada_2_Mjimenez.Service;

namespace Practica_calificada_2_Mjimenez.Controller;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    // GET api/order
    [HttpGet]
    public async Task<IActionResult> GetAllOrdersAndDetails()
    {
        return Ok(await _orderService.GetAllOrdersAndDetails());
    }

    // GET api/order/client/5/products
    [HttpGet("client/{clientId:int}/products")]
    public async Task<IActionResult> GetProductsByClient(int clientId)
    {
        return Ok(await _orderService.GetProductsByClient(clientId));
    }

    // GET api/order/after/2024-01-01
    [HttpGet("after/{date}")]
    public async Task<IActionResult> GetOrdersAfterDate(DateTime date)
    {
        return Ok(await _orderService.GetOrdersAfterDate(date));
    }
}