namespace DoceriaAfetivaGiovanna.Application.DTOs;

public class RecipeResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Yield { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<RecipeIngredientResponseDto> Ingredients { get; set; } = new();
    public List<AdditionalCostDto> AdditionalCosts { get; set; } = new();
    public decimal IngredientsCost { get; set; }
    public decimal AdditionalCostsTotal { get; set; }
    public decimal TotalCost { get; set; }
    public decimal UnitCost { get; set; }
}