namespace Domain.Dtos;

public class GetCustomerDot
{
    public int Id { get; set; }
    public string firstname { get; set; }
    public int orderid { get; set; }
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
    public DateTime CreatedDate { get; set; }
    public int ProductCount { get; set; }
    public decimal Price { get; set; }

    public GetCustomerDot()
    {
        
    }
}