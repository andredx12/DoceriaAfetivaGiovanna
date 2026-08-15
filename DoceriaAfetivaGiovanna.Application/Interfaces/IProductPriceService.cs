using DoceriaAfetivaGiovanna.Application.DTOs;

namespace DoceriaAfetivaGiovanna.Application.Interfaces;

public interface IProductPriceService
{
    Task<ProductPriceResponseDto?> SetPriceAsync(Guid recipeId, ProductPriceRequestDto dto);
    Task<ProductPriceResponseDto?> GetByRecipeIdAsync(Guid recipeId);
}