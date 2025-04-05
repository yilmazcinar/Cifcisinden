using Cifcisinden.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Cifcisinden.WebApi.Models;

public class PutAdvertRequest
{

    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public ServiceCategory ServiceCategory { get; set; }
    public Crop? Crop { get; set; }
    [Required]
    public City City { get; set; }
    [Required]
    public Town Town { get; set; }
    [Required]
    public string Adress { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
}
