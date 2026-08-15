using DoceriaAfetivaGiovanna.Domain.Entities;
using DoceriaAfetivaGiovanna.Domain.Interfaces;
using DoceriaAfetivaGiovanna.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DoceriaAfetivaGiovanna.Infrastructure.Repositories;

public class RecipeRepository : IRecipeRepository
{
    private readonly AppDbContext _context;

    public RecipeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Recipe>> GetAllAsync()
    {
        return await _context.Recipes
            .Include(r => r.RecipeIngredients)
                .ThenInclude(ri => ri.Ingredient)
            .Include(r => r.AdditionalCosts)
            .Include(r => r.ProductPrice)
            .ToListAsync();
    }

    public async Task<Recipe?> GetByIdAsync(Guid id)
    {
        return await _context.Recipes
            .Include(r => r.RecipeIngredients)
                .ThenInclude(ri => ri.Ingredient)
            .Include(r => r.AdditionalCosts)
            .Include(r => r.ProductPrice)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<Ingredient?> GetIngredientByIdAsync(Guid id)
    {
        return await _context.Ingredients.FindAsync(id);
    }

    public async Task AddAsync(Recipe recipe)
    {
        await _context.Recipes.AddAsync(recipe);
    }

    public async Task AddProductPriceAsync(ProductPrice productPrice)
    {
        await _context.ProductPrices.AddAsync(productPrice);
    }

    public void Update(Recipe recipe)
    {
        _context.Recipes.Update(recipe);
    }

    public void Delete(Recipe recipe)
    {
        _context.Recipes.Remove(recipe);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}