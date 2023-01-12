using Domain.Dtos;
using Domain.Entitis;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class ProductController:ControllerBase
{
      private ProductServices _productServices;

      public ProductController()
      {
            _productServices = new ProductServices();
      }

      [HttpGet("GetProducts")]
      public List<Product> GetProducts()
      {
            return _productServices.GetProducts();
      }
      [HttpGet("ProductsTotalAamount")]
      public List<GetProductDto> ProductsTotalAamount()
      {
            return _productServices.ProductsTotalAamount();
      }

      [HttpGet("ProductsSamsungXiaomiApple")]
      public List<Product> ProductsSamsungXiaomi0Apple()
      {
           return _productServices.ProductsSamsungXiaomiApple();
      }
      
      [HttpGet("ProductsNotSamsungXiaomi0Apple")]
      public List<Product> ProductsNotSamsungXiaomi0Apple()
      {
            return _productServices.ProductsNotSamsungXiaomiApple();
      }

      [HttpPost("AddProduct")]
      public void AddProduct(Product product)
      {
            _productServices.AddProduct(product);
      }

      [HttpPut("UpdateProduct")]
      public void UpdateProduct(Product product )
      {
            _productServices.UpdateProduct(product);
      }

      [HttpDelete("DeleteProduct")]
      public void DeliteProduct(int id)
      {
            _productServices.DeleteProduct(id);
      }
      
}