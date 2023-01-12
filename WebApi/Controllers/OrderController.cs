using Domain.Dtos;
using Domain.Entitis;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private OrderServices _orderServices;

    public OrderController()
    {
        _orderServices = new OrderServices();
    }

    [HttpGet("GetOrderFullInfo")]
    public List<GetOrderDto> GetOrderFullInfo()
    {
        var orders = _orderServices.GetOrderInfo();
        return orders;
    }

    [HttpGet("GetOrderCompanyApple")]
    public List<GetOrderDto> GetOrderCompanyApple()
    {
        var orders = _orderServices.GetOrderCompanyApple();
        return orders;
    }

    [HttpGet("GetOrderOverThousand")]
    public List<GetOrderDto> GetOrderOverThousand()
    {
        var orders = _orderServices.GetOrderOverThousand();
        return orders;
    }

    [HttpPost("AddOrder")]
    public void AddOrder(Order order)
    {
        _orderServices.AddOrder((order));
    }

    [HttpPut("UpdateOrder")]
    public void UpdateOrder(Order order)
    {
        _orderServices.UpdateOrder(order);
    }

    [HttpDelete("DeliteOrder")]
    public void DeliteOrder(int id)
    {
        _orderServices.DeliteOrder(id);
    }
}