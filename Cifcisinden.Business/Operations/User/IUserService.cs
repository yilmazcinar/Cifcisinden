using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cifcisinden.Business.Operations.User.Dtos;
using Cifcisinden.Business.Types;

namespace Cifcisinden.Business.Operations.User;

public interface IUserService
{

    Task<ServiceMassage> AddUser(AddUserDto addUserDto);
    
    //Asyn çünkü UnitOfWork ile işlem yapılacak

    ServiceMassage<UserInfoDto> LoginUser(LoginUserDto user);

    Task<List<UserInfoDto>> GetAllUsers();

    Task<ServiceMassage> DeleteUser(int id);

}
