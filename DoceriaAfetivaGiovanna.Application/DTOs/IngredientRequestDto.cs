namespace DoceriaAfetivaGiovanna.Application.DTOs;

public class IngredientRequestDto
{
    public string Name { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public string Unit { get; set; } = string.Empty;
    public decimal PurchasePrice { get; set; }
}