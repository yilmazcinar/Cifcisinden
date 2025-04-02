using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cifcisinden.Data.Enums;

namespace Cifcisinden.Business.Operations.User.Dtos;

public class AddUserDto
{

    public string Email { get; set; }

    public string Password { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public UserStatus UserStatus { get; set; }

    public City City { get; set; }

    public Town Town { get; set; }

    public string Adress { get; set; }

    public DateTime BirthDay { get; set; }

    public string PhoneNumber { get; set; }
}
