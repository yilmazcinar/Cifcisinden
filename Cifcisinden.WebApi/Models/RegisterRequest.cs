using System.ComponentModel.DataAnnotations;
using Cifcisinden.Data.Enums;

namespace Cifcisinden.WebApi.Models;

public class RegisterRequest
{

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
    
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
   
    [Required]
    public UserStatus UserStatus { get; set; }
    
    [Required]
    public City City { get; set; }
   
    [Required]
    public Town Town { get; set; }

    public string Adress { get; set; }
    
    [Required]
    public DateTime BirthDay { get; set; }

    [Required]
    public string PhoneNumber { get; set; }




}
