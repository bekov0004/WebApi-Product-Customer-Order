using Domain.Dtos;

namespace Infrastructure.Services;
using Domain.Entitis;
using Npgsql;
using Dapper;
public class CustomerServices
{
    private string _conectionString = "Server=127.0.0.1;Port=5432;Database=bisnes_db;User Id=postgres;Password=2004;";
     public List<Customer> GetCustomers()
     {
        using(var connection = new NpgsqlConnection(_conectionString))
        {
            string sql = "SELECT * FROM customers";
            var customer =connection.Query<Customer>(sql);
            return customer.ToList();
        }
     }

     public List<GetCustomerDot> GetLeftJoin()
     {
         using (var connection = new NpgsqlConnection(_conectionString))
         {
             string sql = 
             $"SELECT* "+
             $" from customers c "+
             $" left join orders o on c.id = o.customerid ";
             var customer = connection.Query<GetCustomerDot>(sql);
             return customer.ToList();
         }   
     }
     public List<GetCustomerDot> GetFullJoin()
     {
         using (var connection = new NpgsqlConnection(_conectionString))
         {
             string sql = 
                 $"SELECT* "+
                 $" from customers c "+
                 $" FULL outer join orders o on c.id = o.customerid ";
             var customer = connection.Query<GetCustomerDot>(sql);
             return customer.ToList();
         }   
     }
     public List<GetCustomerDot> GetRightJoin()
     {
         using (var connection = new NpgsqlConnection(_conectionString))
         {
             string sql = 
                 $"SELECT* "+
                 $" from customers c "+
                 $" Right join orders o on c.id = o.customerid ";
             var customer = connection.Query<GetCustomerDot>(sql);
             return customer.ToList();
         }   
     }

     public List<GetCustomerDot> GetCustomerAndCountOrders()
     {
         using (var connection = new NpgsqlConnection(_conectionString))
         {
             string sql = 
             $"SELECT "+
             $" c.id,"+
             $" c.firstname, "+
             $" sum(o.productcount) as ProductCount "+
             $" from customers c "+
             $" join orders o on o.customerid = c.id "+
             $" group by c.id,c.firstname "+
             $" ORDER by c.id;";
             var customer = connection.Query<GetCustomerDot>(sql);
             return customer.ToList();
         }
         
     }
     public void AddCustomer(Customer customer)
     {
        using(var connection = new NpgsqlConnection(_conectionString))
        {
            string sql = $"insert into customers (Id, FirstName)"+
                          $"values ('{customer.Id}', '{customer.FirstName}')";
            var add = connection.Execute(sql);
            if (add>0) System.Console.WriteLine("Added");
            else System.Console.WriteLine("Not Added");
        }
     }

     public void UpdatedCustomer(Customer customer)
     {
        using(var connection = new NpgsqlConnection(_conectionString))
        {
            string sql = $"update customers set firstname = '{customer.FirstName}' where id = '{customer.Id}'";
            var update = connection.Execute(sql);
            if (update>0) System.Console.WriteLine("Updated");
            else System.Console.WriteLine("Not Updaated");
        }
     }

     public void Delite(int id)
     {
        using(var connection = new NpgsqlConnection(_conectionString))
        {
            string sql = $"delete from customers where id = {id}";
            var delete = connection.Execute(sql);
            if (delete>0) System.Console.WriteLine("Deleted");
            else System.Console.WriteLine("Not Removed");
        }
     }









}
