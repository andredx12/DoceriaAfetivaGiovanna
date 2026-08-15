using DoceriaAfetivaGiovanna.Application.DTOs;

namespace DoceriaAfetivaGiovanna.Application.Interfaces;

public interface IRecipeService
{
    Task<List<RecipeResponseDto>> GetAllAsync();
    Task<RecipeResponseDto?> GetByIdAsync(Guid id);
    Task<RecipeResponseDto?> CreateAsync(RecipeRequestDto dto);
    Task<bool?> UpdateAsync(Guid id, RecipeRequestDto dto);
    Task<bool> DeleteAsync(Guid id);
}