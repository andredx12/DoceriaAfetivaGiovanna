namespace DoceriaAfetivaGiovanna.Domain.Entities;

public class Recipe
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public int Yield { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
    public ICollection<AdditionalCost> AdditionalCosts { get; set; } = new List<AdditionalCost>();
    public ProductPrice? ProductPrice { get; set; }

    public decimal IngredientsCost =>
        RecipeIngredients.Sum(ri => ri.QuantityUsed * (ri.Ingredient != null ? ri.Ingredient.UnitCost : 0));

    public decimal TotalCost =>
        IngredientsCost + AdditionalCosts.Sum(c => c.Value);

    public decimal UnitCost => Yield > 0 ? TotalCost / Yield : 0;
}