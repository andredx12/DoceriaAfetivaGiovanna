using DoceriaAfetivaGiovanna.Application.DTOs;
using DoceriaAfetivaGiovanna.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoceriaAfetivaGiovanna.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
    private readonly IRecipeService _service;

    public RecipesController(IRecipeService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<RecipeResponseDto>>> GetAll()
    {
        var recipes = await _service.GetAllAsync();
        return Ok(recipes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RecipeResponseDto>> GetById(Guid id)
    {
        var recipe = await _service.GetByIdAsync(id);
        if (recipe is null) return NotFound();
        return Ok(recipe);
    }

    [HttpPost]
    public async Task<ActionResult<RecipeResponseDto>> Create(RecipeRequestDto dto)
    {
        var created = await _service.CreateAsync(dto);
        if (created is null)
            return BadRequest("Um ou mais ingredientes informados não existem.");

        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, RecipeRequestDto dto)
    {
        var result = await _service.UpdateAsync(id, dto);

        if (result is null)
            return BadRequest("Um ou mais ingredientes informados não existem.");

        if (result == false)
            return NotFound();

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