namespace DoceriaAfetivaGiovanna.Application.DTOs;

public class RecipeRequestDto
{
    public string Name { get; set; } = string.Empty;
    public int Yield { get; set; }
    public List<RecipeIngredientRequestDto> Ingredients { get; set; } = new();
    public List<AdditionalCostDto> AdditionalCosts { get; set; } = new();
}