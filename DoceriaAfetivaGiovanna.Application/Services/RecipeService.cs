using DoceriaAfetivaGiovanna.Application.DTOs;
using DoceriaAfetivaGiovanna.Application.Interfaces;
using DoceriaAfetivaGiovanna.Domain.Entities;
using DoceriaAfetivaGiovanna.Domain.Interfaces;

namespace DoceriaAfetivaGiovanna.Application.Services;

public class RecipeService : IRecipeService
{
    private readonly IRecipeRepository _repository;

    public RecipeService(IRecipeRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<RecipeResponseDto>> GetAllAsync()
    {
        var recipes = await _repository.GetAllAsync();
        return recipes.Select(MapToResponseDto).ToList();
    }

    public async Task<RecipeResponseDto?> GetByIdAsync(Guid id)
    {
        var recipe = await _repository.GetByIdAsync(id);
        return recipe is null ? null : MapToResponseDto(recipe);
    }

    public async Task<RecipeResponseDto?> CreateAsync(RecipeRequestDto dto)
    {
        var recipe = new Recipe
        {
            Name = dto.Name,
            Yield = dto.Yield
        };

        foreach (var item in dto.Ingredients)
        {
            var ingredient = await _repository.GetIngredientByIdAsync(item.IngredientId);
            if (ingredient is null) return null;

            recipe.RecipeIngredients.Add(new RecipeIngredient
            {
                IngredientId = item.IngredientId,
                QuantityUsed = item.QuantityUsed,
                Ingredient = ingredient
            });
        }

        foreach (var cost in dto.AdditionalCosts)
        {
            recipe.AdditionalCosts.Add(new AdditionalCost
            {
                Description = cost.Description,
                Value = cost.Value
            });
        }

        await _repository.AddAsync(recipe);
        await _repository.SaveChangesAsync();

        return MapToResponseDto(recipe);
    }

    public async Task<bool?> UpdateAsync(Guid id, RecipeRequestDto dto)
    {
        var recipe = await _repository.GetByIdAsync(id);
        if (recipe is null) return false;

        recipe.Name = dto.Name;
        recipe.Yield = dto.Yield;

        recipe.RecipeIngredients.Clear();
        foreach (var item in dto.Ingredients)
        {
            var ingredient = await _repository.GetIngredientByIdAsync(item.IngredientId);
            if (ingredient is null) return null;

            recipe.RecipeIngredients.Add(new RecipeIngredient
            {
                IngredientId = item.IngredientId,
                QuantityUsed = item.QuantityUsed,
                Ingredient = ingredient
            });
        }

        recipe.AdditionalCosts.Clear();
        foreach (var cost in dto.AdditionalCosts)
        {
            recipe.AdditionalCosts.Add(new AdditionalCost
            {
                Description = cost.Description,
                Value = cost.Value
            });
        }

        _repository.Update(recipe);
        return await _repository.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var recipe = await _repository.GetByIdAsync(id);
        if (recipe is null) return false;

        _repository.Delete(recipe);
        return await _repository.SaveChangesAsync();
    }

    private static RecipeResponseDto MapToResponseDto(Recipe recipe)
    {
        return new RecipeResponseDto
        {
            Id = recipe.Id,
            Name = recipe.Name,
            Yield = recipe.Yield,
            CreatedAt = recipe.CreatedAt,
            Ingredients = recipe.RecipeIngredients.Select(ri => new RecipeIngredientResponseDto
            {
                IngredientId = ri.IngredientId,
                IngredientName = ri.Ingredient?.Name ?? string.Empty,
                QuantityUsed = ri.QuantityUsed,
                Cost = ri.QuantityUsed * (ri.Ingredient?.UnitCost ?? 0)
            }).ToList(),
            AdditionalCosts = recipe.AdditionalCosts.Select(c => new AdditionalCostDto
            {
                Description = c.Description,
                Value = c.Value
            }).ToList(),
            IngredientsCost = recipe.IngredientsCost,
            AdditionalCostsTotal = recipe.AdditionalCosts.Sum(c => c.Value),
            TotalCost = recipe.TotalCost,
            UnitCost = recipe.UnitCost
        };
    }
}