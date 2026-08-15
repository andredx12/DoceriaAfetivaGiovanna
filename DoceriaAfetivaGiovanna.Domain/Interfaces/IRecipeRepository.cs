using DoceriaAfetivaGiovanna.Domain.Entities;

namespace DoceriaAfetivaGiovanna.Domain.Interfaces;

public interface IRecipeRepository
{
    Task<List<Recipe>> GetAllAsync();
    Task<Recipe?> GetByIdAsync(Guid id);
    Task<Ingredient?> GetIngredientByIdAsync(Guid id);
    Task AddAsync(Recipe recipe);
    void Update(Recipe recipe);
    void Delete(Recipe recipe);
    Task<bool> SaveChangesAsync();
}