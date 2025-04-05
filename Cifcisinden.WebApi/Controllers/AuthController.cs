using Cifcisinden.Business.Operations.User;
using Cifcisinden.Business.Operations.User.Dtos;
using Cifcisinden.WebApi.Jwt;
using Cifcisinden.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
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

    [HttpGet("All-Users")]

    public async Task<IActionResult> GetAllUsers()
    {
        var result = await _userService.GetAllUsers();
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }


    [HttpPost("register")]

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

    [HttpPost("login")]

    public IActionResult Login(LoginRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }


        var result = _userService.LoginUser(new LoginUserDto { Email = request.Email, Password = request.Password });

        if (!result.IsSucceed)
        {
            return BadRequest(result.Message);
        }

        var user = result.Data;

        var configuration = HttpContext.RequestServices.GetRequiredService<IConfiguration>();

        var token = JwtHelper.GenerateJwtToken(new JwtDto
        {
            Id = user.Id,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            SecretKey = configuration["Jwt:SecretKey"]!,
            Issuer = configuration["Jwt:Issuer"]!,
            Audience = configuration["Jwt:Audience"]!,
            ExpireMinutes = int.Parse(configuration["Jwt:ExpireMinutes"]!)

        });

        return Ok(new LoginResponse
        {
            Message = "Login successful",
            Token = token,
        });
    }

    [HttpGet("user-info")]
    [Authorize] // Kullanıcı bilgilerini almak için yetkilendirme gerektirir
    public IActionResult GetUserInfo()
    {
        
        return Ok();
    }

}
