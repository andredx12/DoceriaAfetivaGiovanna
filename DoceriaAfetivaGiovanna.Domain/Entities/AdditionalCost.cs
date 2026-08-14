namespace DoceriaAfetivaGiovanna.Domain.Entities;

public class AdditionalCost
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid RecipeId { get; set; }
    public Recipe? Recipe { get; set; }

    public string Description { get; set; } = string.Empty;
    public decimal Value { get; set; }
}
