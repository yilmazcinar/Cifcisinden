using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Cifcisinden.Business.DataProtection;
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
    private readonly IDataProtection _protector;

    public UserManager(IUnitOfWork unitOfWork, IRepository<UserEntity> userRepository, IDataProtection protector)
    {
        _protector = protector;
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
            Password = _protector.Protect(addUserDto.Password),
            FirstName = addUserDto.FirstName,
            LastName = addUserDto.LastName,
            UserStatus = addUserDto.UserStatus,
            City = addUserDto.City,
            Town = addUserDto.Town,
            Adress = addUserDto.Adress ?? string.Empty,
            BirthDay = addUserDto.BirthDay,
            PhoneNumber = _protector.Protect(addUserDto.PhoneNumber),
            UserType = Data.Enums.UserType.Customer,
        };

        _userRepository.Add(user);

        try
        {
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($" {ex.ToString()} + Kullanıcı kaydı sırasında hata oluştu ");
        }

        return new ServiceMassage
        {
            IsSucceed = true,
            Message = "Kullanıcı başarıyla kaydedildi"
        };
    }

    public async Task<List<UserInfoDto>> GetAllUsers()
    {
        var users = _userRepository.GetAll()
            .Select(x => new UserInfoDto
            {
                Id = x.Id,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                UserType = x.UserType,
            }).ToList();

        return await Task.FromResult(users);
    }

    public ServiceMassage<UserInfoDto> LoginUser(LoginUserDto user)
    {
        var userEntity = _userRepository.Get(x => x.Email.ToLower() == user.Email.ToLower());

        if (userEntity == null)
        {
            return new ServiceMassage<UserInfoDto>
            {
                IsSucceed = false,
                Message = "Kullanıcı adı veya şifre hatalı"
            };
        }

        var unprotectedPassword = _protector.UnProtect(userEntity.Password);

        if (user.Password != unprotectedPassword)
        {
            return new ServiceMassage<UserInfoDto>
            {
                IsSucceed = false,
                Message = "Kullanıcı adı veya şifre hatalı"
            };
        }
        else
        {
            return new ServiceMassage<UserInfoDto>
            { 
                IsSucceed = true,
                Data = new UserInfoDto 
                {
                    Email = userEntity.Email,
                    FirstName = userEntity.FirstName,
                    LastName = userEntity.LastName,
                    UserType = userEntity.UserType,
                }

            };  
        }

    }

    
}
