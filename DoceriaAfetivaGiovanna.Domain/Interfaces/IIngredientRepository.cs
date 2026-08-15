using DoceriaAfetivaGiovanna.Domain.Entities;

namespace DoceriaAfetivaGiovanna.Domain.Interfaces;

public interface IIngredientRepository
{
    Task<List<Ingredient>> GetAllAsync();
    Task<Ingredient?> GetByIdAsync(Guid id);
    Task AddAsync(Ingredient ingredient);
    void Update(Ingredient ingredient);
    void Delete(Ingredient ingredient);
    Task<bool> SaveChangesAsync();
}