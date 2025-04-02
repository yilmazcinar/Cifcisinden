using Cifcisinden.Business.Operations.User;
using Cifcisinden.Business.Operations.User.Dtos;
using Cifcisinden.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cifcisinden.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{

    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]

    public async Task<IActionResult> Register(RegisterRequest request) 
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }//TODO: ileride action filter olarak kodlanacak. 

        var addUserDto = new AddUserDto
        {
            Email = request.Email,
            Password = request.Password,
            FirstName = request.FirstName,
            LastName = request.LastName,
            UserStatus = request.UserStatus,
            City = request.City,
            Town = request.Town,
            Adress = request.Adress,
            BirthDay = request.BirthDay,
            PhoneNumber = request.PhoneNumber
        };

        var result = await _userService.AddUser(addUserDto);

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
