namespace DoceriaAfetivaGiovanna.Domain.Entities;

public class Ingredient
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public string Unit { get; set; } = string.Empty;
    public decimal PurchasePrice { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // RN01: Custo unitário = Valor pago ÷ Quantidade comprada
    public decimal UnitCost => Quantity > 0 ? PurchasePrice / Quantity : 0;

    public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
}