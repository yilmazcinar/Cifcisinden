using Cifcisinden.Business.Operations.Advert;
using Cifcisinden.Business.Operations.Advert.Dtos;
using Cifcisinden.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cifcisinden.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdvertController : ControllerBase
{
    private readonly IAdvertService _advertService;
    public AdvertController(IAdvertService service)
    {
        _advertService = service;
    }


    [HttpGet("getbyid/{id}")]
    public async Task<IActionResult> GetAdvert(int id)
    {
        var result = await _advertService.GetAdvert(id);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }


    [HttpGet("getall")]
    public async Task<IActionResult> GetAllAdverts()
    {
        var result = await _advertService.GetAllAdverts();

        return Ok(result);
    }



    [HttpPost("add")]
    [Authorize]
    public async Task<IActionResult> AddAdvert(AddAdvertRequest request)
    {
        var addAdvertDto = new AddAdvertDto
        {
            Title = request.Title,
            Description = request.Description,
            ServiceCategory = request.ServiceCategory,
            Crop = request.Crop,
            City = request.City,
            Town = request.Town,
            Adress = request.Adress,
            PhoneNumber = request.PhoneNumber,
            UserId = request.UserId
        };

        var result = await _advertService.AddAdvert(addAdvertDto);

        if (result.IsSucceed)
        {
            return Ok();
        }
        else
        {
            return BadRequest(result.Message);
        }
    }

    [HttpPatch("{id}/description")]
    [Authorize]

    public async Task<IActionResult> UpdateAdvert(int id, UpdateAdvertRequest request)
    {
        var result = await _advertService.UpdateAdvert(id, new UpdateAdvertDto
        {
            Description = request.Description,

        });

        if (result.IsSucceed)
        {
            return Ok();
        }
        else
        {
            return BadRequest(result.Message);
        }

    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteAdvert(int id)
    {
        var result = await _advertService.DeleteAdvert(id);
        if (result.IsSucceed)
        {
            return Ok();
        }
        else
        {
            return BadRequest(result.Message);
        }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> PutAdvert(int id, PutAdvertRequest request)
    {
        var result = await _advertService.PutAdvert(id, new PutAdvertDto
        {
            Title = request.Title,
            Description = request.Description,
            ServiceCategory = request.ServiceCategory,
            Crop = request.Crop,
            City = request.City,
            Town = request.Town,
            Adress = request.Adress,
            PhoneNumber = request.PhoneNumber
        });
        if (result.IsSucceed)
        {
            return Ok();
        }
        else
        {
            
            return BadRequest(result.Message);
        }


    }
}