using DoceriaAfetivaGiovanna.Application.DTOs;
using DoceriaAfetivaGiovanna.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoceriaAfetivaGiovanna.API.Controllers;

[ApiController]
[Route("api/recipes/{recipeId}/price")]
public class ProductPricesController : ControllerBase
{
    private readonly IProductPriceService _service;

    public ProductPricesController(IProductPriceService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<ProductPriceResponseDto>> GetPrice(Guid recipeId)
    {
        var result = await _service.GetByRecipeIdAsync(recipeId);
        if (result is null) return NotFound();
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<ProductPriceResponseDto>> SetPrice(Guid recipeId, ProductPriceRequestDto dto)
    {
        var result = await _service.SetPriceAsync(recipeId, dto);
        if (result is null) return NotFound();
        return Ok(result);
    }
}