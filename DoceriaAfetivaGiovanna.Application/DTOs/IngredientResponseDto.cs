namespace DoceriaAfetivaGiovanna.Application.DTOs;

public class IngredientResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public string Unit { get; set; } = string.Empty;
    public decimal PurchasePrice { get; set; }
    public decimal UnitCost { get; set; }
    public DateTime CreatedAt { get; set; }
}