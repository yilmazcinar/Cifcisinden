using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Cifcisinden.Business.Operations.User.Dtos;
using Cifcisinden.Business.Types;
using Cifcisinden.Data.Entities;
using Cifcisinden.Data.Repositories;
using Cifcisinden.Data.UnitOfWork;

namespace Cifcisinden.Business.Operations.User;

public class UserManager : IUserService
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepository<UserEntity> _userRepository;

    public UserManager(IUnitOfWork unitOfWork, IRepository<UserEntity> userRepository)
    {

        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }


    public async Task<ServiceMassage> AddUser(AddUserDto addUserDto)
    {
        var hasMail = _userRepository.GetAll(x => x.Email.ToLower() == addUserDto.Email.ToLower());

        if (hasMail.Any())
        {
            return new ServiceMassage
            {
                IsSucceed = false,
                Message = "Bu mail adresi ile kayıtlı kullanıcı mevcut"
            };
        }

        var user = new UserEntity
        {
            Email = addUserDto.Email,
            Password = addUserDto.Password,
            FirstName = addUserDto.FirstName,
            LastName = addUserDto.LastName,
            UserStatus = addUserDto.UserStatus,
            City = addUserDto.City,
            Town = addUserDto.Town,
            Adress = addUserDto.Adress,
            BirthDay = addUserDto.BirthDay,
            PhoneNumber = addUserDto.PhoneNumber
        };

        _userRepository.Add(user);

        try
        {
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception)
        {

            throw new Exception("Kullanıcı kaydı sırasında hata oluştu");
        }

        return new ServiceMassage
        {
            IsSucceed = true,
            Message = "Kullanıcı başarıyla kaydedildi"
        };
    }
}
