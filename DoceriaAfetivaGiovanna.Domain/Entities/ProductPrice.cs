namespace DoceriaAfetivaGiovanna.Domain.Entities;

public class ProductPrice
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid RecipeId { get; set; }
    public Recipe? Recipe { get; set; }

    public decimal SalePrice { get; set; }
}