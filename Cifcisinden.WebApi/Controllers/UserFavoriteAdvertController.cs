using Cifcisinden.Business.Operations.UserFavoriteAdvert;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cifcisinden.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserFavoriteAdvertController : ControllerBase
{
    private readonly IUserFavoriteAdvertService _service;

    public UserFavoriteAdvertController(IUserFavoriteAdvertService service)
    {
        _service = service;
    }

    [HttpPost("add")]
    [Authorize]
    public async Task<IActionResult> AddToFavorites(int userId, int advertId)
    {
  
        await _service.AddToFavorites(userId, advertId);
        return Ok(new { message = "Favori ilanlara eklendi." });
    }

    [HttpDelete("remove")]
    [Authorize]
    public async Task<IActionResult> RemoveFromFavorites(int userId, int advertId)
    {
        await _service.RemoveFromFavorites(userId, advertId);
        return Ok(new { message = "Favori ilanlardan çıkarıldı." });
    }

    [HttpGet("user/{userId}")]
    [Authorize]
    public async Task<IActionResult> GetUserFavorites(int userId)
    {
        var favorites = await _service.GetUserFavorites(userId);
        return Ok(favorites);
    }
}
