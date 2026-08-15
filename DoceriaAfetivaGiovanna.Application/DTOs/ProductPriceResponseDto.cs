namespace DoceriaAfetivaGiovanna.Application.DTOs;

public class ProductPriceResponseDto
{
    public Guid RecipeId { get; set; }
    public string RecipeName { get; set; } = string.Empty;
    public decimal UnitCost { get; set; }
    public decimal SalePrice { get; set; }
    public decimal UnitProfit { get; set; }
    public decimal ProfitMargin { get; set; }
}