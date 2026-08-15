using DoceriaAfetivaGiovanna.Application.DTOs;
using DoceriaAfetivaGiovanna.Application.Interfaces;
using DoceriaAfetivaGiovanna.Domain.Entities;
using DoceriaAfetivaGiovanna.Domain.Interfaces;

namespace DoceriaAfetivaGiovanna.Application.Services;

public class IngredientService : IIngredientService
{
    private readonly IIngredientRepository _repository;

    public IngredientService(IIngredientRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<IngredientResponseDto>> GetAllAsync()
    {
        var ingredients = await _repository.GetAllAsync();
        return ingredients.Select(MapToResponseDto).ToList();
    }

    public async Task<IngredientResponseDto?> GetByIdAsync(Guid id)
    {
        var ingredient = await _repository.GetByIdAsync(id);
        return ingredient is null ? null : MapToResponseDto(ingredient);
    }

    public async Task<IngredientResponseDto> CreateAsync(IngredientRequestDto dto)
    {
        var ingredient = new Ingredient
        {
            Name = dto.Name,
            Quantity = dto.Quantity,
            Unit = dto.Unit,
            PurchasePrice = dto.PurchasePrice
        };

        await _repository.AddAsync(ingredient);
        await _repository.SaveChangesAsync();

        return MapToResponseDto(ingredient);
    }

    public async Task<bool> UpdateAsync(Guid id, IngredientRequestDto dto)
    {
        var ingredient = await _repository.GetByIdAsync(id);
        if (ingredient is null) return false;

        ingredient.Name = dto.Name;
        ingredient.Quantity = dto.Quantity;
        ingredient.Unit = dto.Unit;
        ingredient.PurchasePrice = dto.PurchasePrice;

        _repository.Update(ingredient);
        return await _repository.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var ingredient = await _repository.GetByIdAsync(id);
        if (ingredient is null) return false;

        _repository.Delete(ingredient);
        return await _repository.SaveChangesAsync();
    }

    private static IngredientResponseDto MapToResponseDto(Ingredient ingredient)
    {
        return new IngredientResponseDto
        {
            Id = ingredient.Id,
            Name = ingredient.Name,
            Quantity = ingredient.Quantity,
            Unit = ingredient.Unit,
            PurchasePrice = ingredient.PurchasePrice,
            UnitCost = ingredient.UnitCost,
            CreatedAt = ingredient.CreatedAt
        };
    }
}