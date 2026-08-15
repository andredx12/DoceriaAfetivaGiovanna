namespace DoceriaAfetivaGiovanna.Application.DTOs;

public class RecipeIngredientResponseDto
{
    public Guid IngredientId { get; set; }
    public string IngredientName { get; set; } = string.Empty;
    public decimal QuantityUsed { get; set; }
    public decimal Cost { get; set; }
}