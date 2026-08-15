using DoceriaAfetivaGiovanna.Application.DTOs;
using DoceriaAfetivaGiovanna.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoceriaAfetivaGiovanna.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IngredientsController : ControllerBase
{
    private readonly IIngredientService _service;

    public IngredientsController(IIngredientService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<IngredientResponseDto>>> GetAll()
    {
        var ingredients = await _service.GetAllAsync();
        return Ok(ingredients);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IngredientResponseDto>> GetById(Guid id)
    {
        var ingredient = await _service.GetByIdAsync(id);
        if (ingredient is null) return NotFound();
        return Ok(ingredient);
    }

    [HttpPost]
    public async Task<ActionResult<IngredientResponseDto>> Create(IngredientRequestDto dto)
    {
        var created = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, IngredientRequestDto dto)
    {
        var updated = await _service.UpdateAsync(id, dto);
        if (!updated) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _service.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}