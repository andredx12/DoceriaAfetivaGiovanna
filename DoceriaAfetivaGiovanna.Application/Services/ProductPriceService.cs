using DoceriaAfetivaGiovanna.Application.DTOs;
using DoceriaAfetivaGiovanna.Application.Interfaces;
using DoceriaAfetivaGiovanna.Domain.Entities;
using DoceriaAfetivaGiovanna.Domain.Interfaces;

namespace DoceriaAfetivaGiovanna.Application.Services;

public class ProductPriceService : IProductPriceService
{
    private readonly IRecipeRepository _repository;

    public ProductPriceService(IRecipeRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductPriceResponseDto?> SetPriceAsync(Guid recipeId, ProductPriceRequestDto dto)
    {
        var recipe = await _repository.GetByIdAsync(recipeId);
        if (recipe is null) return null;

        if (recipe.ProductPrice is null)
        {
            var newPrice = new ProductPrice
            {
                RecipeId = recipe.Id,
                SalePrice = dto.SalePrice
            };

            await _repository.AddProductPriceAsync(newPrice);
            recipe.ProductPrice = newPrice;
        }
        else
        {
            recipe.ProductPrice.SalePrice = dto.SalePrice;
        }

        await _repository.SaveChangesAsync();

        return MapToResponseDto(recipe);
    }

    public async Task<ProductPriceResponseDto?> GetByRecipeIdAsync(Guid recipeId)
    {
        var recipe = await _repository.GetByIdAsync(recipeId);
        if (recipe is null || recipe.ProductPrice is null) return null;

        return MapToResponseDto(recipe);
    }

    private static ProductPriceResponseDto MapToResponseDto(Recipe recipe)
    {
        var salePrice = recipe.ProductPrice?.SalePrice ?? 0;
        var unitCost = recipe.UnitCost;

        var unitProfit = salePrice - unitCost;
        var profitMargin = salePrice > 0 ? Math.Round((unitProfit / salePrice) * 100, 2) : 0;

        return new ProductPriceResponseDto
        {
            RecipeId = recipe.Id,
            RecipeName = recipe.Name,
            UnitCost = unitCost,
            SalePrice = salePrice,
            UnitProfit = unitProfit,
            ProfitMargin = profitMargin
        };
    }
}