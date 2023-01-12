using Domain.Entitis;
using Infrastructure.Services;
var customerServices = new CustomerServices();
var orderServices = new OrderServices();
var productServices = new ProductServices();
AddOrder();

void ShowCustomer()
{
  var allCustomer =customerServices.GetCustomers();
foreach (var cu in allCustomer)
{
    System.Console.WriteLine($"Id: {cu.Id}  FirstName: {cu.FirstName}");
}
}
void AddCustomer()
{
    var custome= new Customer()
    {
        Id = 21,
        FirstName = "Muhammad"
    };
    customerServices.AddCustomer(custome);
}
void UpdatedCustomer()
{
    var upc = new Customer()
    {
        Id = 21,
        FirstName = "Yaaqubzoda",
    };
    customerServices.UpdatedCustomer(upc);
}
void DeleteCustomer(int id)
{
    customerServices.Delite(id);
}


void AddProduct()
{
    var pro = new Product()
    {
        ProductName = "Huawei Mate 8",
        Company = "Huaewi",
        ProductCount = 10,
        Price = 500,
    };
    productServices.AddProduct(pro);
}

void ShowProduct()
{
  var allProduct = productServices.GetProducts();
foreach (var cu in allProduct)
{
   // System.Console.WriteLine($"Id: {cu.Id}   ProductId: {cu.ProductId}  CustomerId: {cu.CustomerId}  CreatedAt: {cu.CreatedAt}  ProductCount: {cu.ProductCount}  Price: {cu.Price}");
   System.Console.WriteLine($"Id: {cu.Id}  ProductName: {cu.ProductName}  Company:{cu.Company}  ProductCount:{cu.ProductCount}  Price:{cu.Price}");
}
}

void UpdateProduct()
{
    var pro = new Product()
    {
        Id = 21,
        ProductName = "Toj x pro",
        Company = "Tojiki",
        ProductCount = 20,
        Price = 1000,
    };
    productServices.UpdateProduct(pro);
}

void DeleteProduct(int id)
{
  productServices.Delete(id);
}

void ShowOrder()
{
var allCustomer =orderServices.GetOrders();
foreach (var or in allCustomer)
{
    System.Console.WriteLine($"Id: {or.Id}  ProductId: {or.ProductId}  CustomerId: {or.CustomerId}"+
      $"CreatedAt: {or.CreatedDate}  ProductCount: {or.ProductCount}  Price: {or.Price}");
}
}
void AddOrder()
{
    var order= new Order()
    {
        ProductId = 5,
        CustomerId = 5,
        CreatedDate = new DateTime(2023,11,24),
        ProductCount = 15,
        Price = 500,
    };
    orderServices.AddOrder(order);
}
void UpdatedOrder()
{
    var order = new Order()
    {
        Id = 26,
        ProductId = 5,
        CustomerId = 5,
        CreatedDate = new DateTime(2023,12,30),
        ProductCount = 50,
        Price = 100,
    };
    orderServices.UpdateOrder(order);
}
void DeleteOrder(int id)
{
    orderServices.DeliteOrder(id);
}