using DoceriaAfetivaGiovanna.Domain.Entities;
using DoceriaAfetivaGiovanna.Domain.Interfaces;
using DoceriaAfetivaGiovanna.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DoceriaAfetivaGiovanna.Infrastructure.Repositories;

public class IngredientRepository : IIngredientRepository
{
    private readonly AppDbContext _context;

    public IngredientRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Ingredient>> GetAllAsync()
    {
        return await _context.Ingredients.ToListAsync();
    }

    public async Task<Ingredient?> GetByIdAsync(Guid id)
    {
        return await _context.Ingredients.FindAsync(id);
    }

    public async Task AddAsync(Ingredient ingredient)
    {
        await _context.Ingredients.AddAsync(ingredient);
    }

    public void Update(Ingredient ingredient)
    {
        _context.Ingredients.Update(ingredient);
    }

    public void Delete(Ingredient ingredient)
    {
        _context.Ingredients.Remove(ingredient);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}