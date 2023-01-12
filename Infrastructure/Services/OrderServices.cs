using Domain.Entitis;
using Npgsql;
using Dapper;
using Domain.Dtos;

namespace Infrastructure.Services;

public class OrderServices
{
    private string _conectionString = "Server=127.0.0.1;Port=5432;Database=bisnes_db;User Id=postgres;Password=2004;";
    
    public List<Order> GetOrders()
    {
        using(var connection = new NpgsqlConnection(_conectionString))
        {
            string sql = $"select * from orders";
             var order = connection.Query<Order>(sql);
             return order.ToList();

        }
    }

    public List<GetOrderDto> GetOrderInfo()
    {
        using (var connection = new NpgsqlConnection(_conectionString))
        {
            string sql = $"select o.id, p.id as ProductId, c.id as CustomerId, o.createdat as CreatedDate, o.productcount as ProductCount, o.price as Price, p.productname as ProductName, c.firstname from orders o join customers c on c.id = o.customerid join products p on o.productid = p.id";
            var result = connection.Query<GetOrderDto>(sql);
            return result.ToList();
        }
    }

    public List<GetOrderDto> GetOrderCompanyApple()
    {
        using (var connection = new NpgsqlConnection(_conectionString))
        {
            string sql = $"select o.id, p.id as ProductId, c.id as CustomerId, o.createdat as CreatedDate, o.productcount as ProductCount, o.price as Price, p.productname as ProductName, c.firstname from orders o join customers c on c.id = o.customerid join products p on o.productid = p.id WHERE p.company = 'Apple' ";
            var result = connection.Query<GetOrderDto>(sql);
            return result.ToList();
        }
    }

    public List<GetOrderDto> GetOrderOverThousand()
    {
        using (var connection = new NpgsqlConnection(_conectionString) )
        {
            string sql = 
            $"select "+ 
            $" o.id ,"+
            $" p.id as ProductId , "+
            $" c.id as CustomerId , "+
            $" o.createdat as CreatedDate , "+
            $" o.productcount as ProductCount , "+
            $" sum(o.price*o.productcount) as Price ,"+ 
            $" p.productname as ProductName , "+
            $" c.firstname "+
            $" from orders o "+
            $" join customers c on c.id = o.customerid "+
            $" join products p on o.productid = p.id "+
            $" GROUP by o.productid,o.id,p.id,c.id,o.createdat,o.productcount,o.price,p.productname,c.firstname "+
            $" HAVING sum(o.price)*o.productcount>1000 ";
            var result = connection.Query<GetOrderDto>(sql);
            return result.ToList();
        }
    }
    public void AddOrder(Order order)
    {
        using(var connection = new NpgsqlConnection(_conectionString))
        {
            string sql = $"insert into orders (ProductId, CustomerId, CreatedAt, ProductCount, Price)"+
                        $"values('{order.ProductId}','{order.CustomerId}','{order.CreatedDate}','{order.ProductCount}','{order.Price}')";
            var add = connection.Execute(sql);
            if (add>0) System.Console.WriteLine("Added");
            else System.Console.WriteLine("Not Added");
        }

    }
    public void UpdateOrder(Order order)
    {
        using(var connection = new NpgsqlConnection(_conectionString))
        {
            string sql = $"update orders set ProductId = '{order.ProductId}', CustomerId= '{order.CustomerId}', CreatedAt= '{order.CreatedDate}', ProductCount= '{order.ProductCount}', Price= '{order.ProductCount}' where id = {order.Id}";
            var update = connection.Execute(sql);
            if (update>0) System.Console.WriteLine("Updated");
            else System.Console.WriteLine("Not Updaated");
        }

    }
    public void DeliteOrder(int id)
    {
        using(var connection = new NpgsqlConnection(_conectionString))
        {
            string sql = $"delete from orders where id = {id}";
            var delete = connection.Execute(sql);
            if (delete>0) System.Console.WriteLine("Deleted");
            else System.Console.WriteLine("Not Removed");

        }
    }




}
