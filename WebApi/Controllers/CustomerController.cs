using Domain.Dtos;

namespace WebApi.Controllers;
using Infrastructure.Services;
using Domain.Entitis;
using Microsoft.AspNetCore.Mvc;
    [ApiController]
    [Route("[controller]")]
public class CustomerController:ControllerBase
{
  private CustomerServices _customerServices;
  public CustomerController()
  {
    _customerServices = new CustomerServices();
  }
  [HttpGet("GetCustomers")]
  public List<Customer> Customers()
  {
    return _customerServices.GetCustomers();
  }

  [HttpGet("GetLeftJoin")]
  public List<GetCustomerDot> GetLeftJoin()
  {
    return _customerServices.GetLeftJoin();
  }
  
    [HttpGet("GetFullJoin")]
    public List<GetCustomerDot> GetFullJoin()
    {
      return _customerServices.GetFullJoin();
    }
  
  [HttpGet("GetRightJoin")]
  public List<GetCustomerDot> GetRightJoin()
  {
    return _customerServices.GetRightJoin();
  }

  [HttpGet("GetCustomerAndCountOrders")]
  public List<GetCustomerDot> GetCustomerAndCountOrders()
  {
    return _customerServices.GetCustomerAndCountOrders();
  }

  [HttpPost("AddCustomer")]
  public void Add(Customer customer)
  {
     _customerServices.AddCustomer(customer);
  }
  [HttpPut("Update")]
   public void UpdateCustomer(Customer customer)
   {
    _customerServices.UpdatedCustomer(customer);
   }
   [HttpDelete("Delete")]
   public void DeleteCustomer(int id)
   {
     _customerServices.Delite(id);
   }
    
}
