namespace apiExemplo.src.Requests.Product;

public class CreateProductRequest : Request
{
    public string Code { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string UnitOfMeasure { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Warehouse { get; set; } = string.Empty;
    public int StockQuantity { get; set; } = 0;
    public string Batch { get; set; } = string.Empty;
    public DateTime ExpirationDate { get; set; } = DateTime.MinValue;
    public bool Status { get; set; } = false;
    public string Image { get; set; } = string.Empty;
}