using Cifcisinden.Business.Operations.Setting;
using Cifcisinden.WebApi.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cifcisinden.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SettingController : ControllerBase
{
    private readonly ISettingService _settingService;

    public SettingController(ISettingService settingService)
    {
        _settingService = settingService;
    }


    [HttpPatch]
    [Authorize(Roles = "Admin")]
    [TimeControlFilter]
    public async Task<IActionResult> ToggleMaintenence()
    {
        await _settingService.ToggleMaintenenceMode();
        return Ok();
    }

}
