using DoceriaAfetivaGiovanna.Application.DTOs;

namespace DoceriaAfetivaGiovanna.Application.Interfaces;

public interface IIngredientService
{
    Task<List<IngredientResponseDto>> GetAllAsync();
    Task<IngredientResponseDto?> GetByIdAsync(Guid id);
    Task<IngredientResponseDto> CreateAsync(IngredientRequestDto dto);
    Task<bool> UpdateAsync(Guid id, IngredientRequestDto dto);
    Task<bool> DeleteAsync(Guid id);
}