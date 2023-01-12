using System.Data;
using System.Net.Sockets;
using Domain.Entitis;
using Npgsql;
using Dapper;
using Domain.Dtos;

namespace Infrastructure.Services;  

public class ProductServices
{
    private string _conectionString = "Server=127.0.0.1;Port=5432;Database=bisnes_db;User Id=postgres;Password=2004;";
    public List<Product> GetProducts()
    {
        using(var connection = new NpgsqlConnection(_conectionString))
        {
            string sql = "SELECT * FROM products;";
            var prosuct = connection.Query<Product>(sql);
            return prosuct.ToList();

        }
    }

    public List<GetProductDto> ProductsTotalAamount()
    {
        using(var connection = new NpgsqlConnection(_conectionString))
        {
            string sql = 
            $"SELECT "+
            $" p.id, "+
            $" p.productname, "+
            $" sum(o.price*o.productcount) as price "+
            $" from products p "+
            $" join orders o on o.productid = p.id "+
            $" group by p.id,p.productname,o.productcount "+
            $" order by p.id ";
            var product = connection.Query<GetProductDto>(sql);
            return product.ToList();
        }
    }

    public List<Product> ProductsSamsungXiaomiApple()
    {
        using (var connection = new NpgsqlConnection(_conectionString))
        {
            string sql = 
            $" select * "+
            $" from Products "+ 
            $" where company in ('Samsung','Xiaomi','Apple') ";
            var product = connection.Query<Product>(sql);
            return product.ToList();
        }
    }
    
    public List<Product> ProductsNotSamsungXiaomiApple()
    {
        using (var connection = new NpgsqlConnection(_conectionString))
        {
            string sql = 
                $" select * "+
                $" from Products "+ 
                $" where company not in ('Samsung','Xiaomi','Apple') ";
            var product = connection.Query<Product>(sql);
            return product.ToList();
        }
    }


    public void AddProduct(Product product)
    {
        using(var connection = new NpgsqlConnection(_conectionString))
        {
            string sql = $"INSERT INTO Products (ProductName, Company, ProductCount, Price)"+
                         $"VALUES ('{product.ProductName}', '{product.Company}', '{product.ProductCount}', '{product.Price}')";
            var add = connection.Execute(sql);
            if (add>0) System.Console.WriteLine("Added");
            else System.Console.WriteLine("Not Added");
            
        }
    }

    public void UpdateProduct(Product product)
    {
        using (var connection = new NpgsqlConnection(_conectionString))
        {           
            string sql = $"update products set ProductName = '{product.ProductName}',Company = '{product.Company}',ProductCount = '{product.ProductCount}',Price = '{product.Price}'"+
            $"where id = '{product.Id}'";
            var update = connection.Execute(sql);
             if (update>0) System.Console.WriteLine("Updated");
            else System.Console.WriteLine("Not Updaated");
        }
    }

    public void DeleteProduct(int id)
    {
        using(var  connection =new NpgsqlConnection(_conectionString))
        {
           string sql =$"delete from products where id = {id}";
           var delete =connection.Execute(sql);
           if (delete>0) System.Console.WriteLine("Deleted");
            else System.Console.WriteLine("Not Removed");
        }   
    }
}
