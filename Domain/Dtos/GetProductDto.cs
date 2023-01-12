namespace Domain.Dtos;

public class GetProductDto
{
    public string ProductName { get; set; }
    public string Company { get; set; }
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
    public DateTime CreatedDate { get; set; }
    public int ProductCount { get; set; }
    public decimal Price { get; set; }

    public GetProductDto()
    {
        
    }
}