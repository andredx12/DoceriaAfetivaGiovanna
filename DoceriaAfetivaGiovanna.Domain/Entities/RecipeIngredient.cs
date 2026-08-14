namespace DoceriaAfetivaGiovanna.Domain.Entities;

public class RecipeIngredient
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid RecipeId { get; set; }
    public Recipe? Recipe { get; set; }

    public Guid IngredientId { get; set; }
    public Ingredient? Ingredient { get; set; }

    public decimal QuantityUsed { get; set; }
}