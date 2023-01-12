namespace Domain.Entitis;

public class Order 
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
    public DateTime CreatedDate { get; set; }
    public int ProductCount { get; set; }
    public int Price { get; set; }
}
