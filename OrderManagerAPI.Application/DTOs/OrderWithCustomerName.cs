namespace OrderManagerAPI.Application.DTOs;

public class OrderWithCustomerName
{
    public int OrderId { get; set; }
    public int Quantity { get; set; }
    public DateTime OrderDate { get; set; }
    public string? Name { get; set; }
}