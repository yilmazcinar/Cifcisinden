using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cifcisinden.Business.Operations.Advert.Dtos;
using Cifcisinden.Business.Types;
using Cifcisinden.Data.Entities;
using Cifcisinden.Data.Repositories;
using Cifcisinden.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Cifcisinden.Business.Operations.Advert;

public class AdvertManager : IAdvertService
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly IRepository<AdvertEntity> _advertRepository;

    public AdvertManager(IUnitOfWork unitOfWork, IRepository<AdvertEntity> repository)
    {
        _unitOfWork = unitOfWork;
        _advertRepository = repository;
    }

    public async Task<ServiceMassage> AddAdvert(AddAdvertDto advert)
    {
        var hasAdvert = _advertRepository
            .GetAll()
            .Any(x => x.Title == advert.Title && x.ServiceCategory == advert.ServiceCategory && x.PhoneNumber == advert.PhoneNumber && x.City == advert.City && x.Town == advert.Town);

        if (hasAdvert)
        {
            return new ServiceMassage
            {
                IsSucceed = false,
                Message = "Bu ilan zaten mevcut."
            };
        }

        var advertEntity = new AdvertEntity
        {
            Title = advert.Title,
            Description = advert.Description,
            ServiceCategory = advert.ServiceCategory,
            Crop = advert.Crop,
            City = advert.City,
            Town = advert.Town,
            Adress = advert.Adress,
            PhoneNumber = advert.PhoneNumber,
            UserId = advert.UserId
        };

        _advertRepository.Add(advertEntity);

        try
        {
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($" {ex} İlan eklenirken bir hata oluştu.");
        }

        return new ServiceMassage
        {
            IsSucceed = true,
            Message = "İlan başarıyla eklendi."
        };
    }

    public Task<ServiceMassage> DeleteAdvert(int id)
    {

        var advert = _advertRepository.GetAll().FirstOrDefault(x => x.Id == id);
        if (advert == null)
        {
            return Task.FromResult(new ServiceMassage
            {
                IsSucceed = false,
                Message = "İlan bulunamadı."
            });
        }
        _advertRepository.Delete(advert);
        try
        {
            _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($" {ex} İlan silinirken bir hata oluştu.");
        }
        return Task.FromResult(new ServiceMassage
        {
            IsSucceed = true,
            Message = "İlan başarıyla silindi."
        });

    }

    public Task<AdvertDto> GetAdvert(int id)
    {
        var advert = _advertRepository.GetAll(x => x.Id == id).Select(x => new AdvertDto
        {
            Id = x.Id,
            Title = x.Title,
            Description = x.Description,
            ServiceCategory = x.ServiceCategory,
            Crop = x.Crop,
            City = x.City,
            Town = x.Town,
            Adress = x.Adress,
            PhoneNumber = x.PhoneNumber
        }).FirstOrDefaultAsync(x => x.Id == id);

        return advert;
    }

    public async Task<List<AdvertDto>> GetAllAdverts()
    {
        var adverts = await _advertRepository.GetAll().Select(x => new AdvertDto
        {
            Id = x.Id,
            Title = x.Title,
            Description = x.Description,
            ServiceCategory = x.ServiceCategory,
            Crop = x.Crop,
            City = x.City,
            Town = x.Town,
            Adress = x.Adress,
            PhoneNumber = x.PhoneNumber
        }).ToListAsync();

        return adverts;
    }

    public async Task<ServiceMassage> PutAdvert(int id, PutAdvertDto putAdvertDto)
    {

        var advert = _advertRepository.GetAll().FirstOrDefault(x => x.Id == id);
        if (advert == null)
        {
            return await Task.FromResult(new ServiceMassage
            {
                IsSucceed = false,
                Message = "İlan bulunamadı."
            });
        }
        
        advert.Title = putAdvertDto.Title;
        advert.Description = putAdvertDto.Description;
        advert.ServiceCategory = putAdvertDto.ServiceCategory;
        advert.Crop = putAdvertDto.Crop;
        advert.City = putAdvertDto.City;
        advert.Town = putAdvertDto.Town;
        advert.Adress = putAdvertDto.Adress;
        advert.PhoneNumber = putAdvertDto.PhoneNumber;


        _advertRepository.Update(advert);
        try
        {
            _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackTransaction();
            throw new Exception($" {ex} İlan güncellenirken bir hata oluştu.");
        }
        return await Task.FromResult(new ServiceMassage
        {
            IsSucceed = true,
            Message = "İlan başarıyla güncellendi."
        });
    }

    public Task<ServiceMassage> UpdateAdvert(int id, UpdateAdvertDto updateAdvertDto)
    {

        var advert = _advertRepository.GetAll().FirstOrDefault(x => x.Id == id);
        if (advert == null)
        {
            return Task.FromResult(new ServiceMassage
            {
                IsSucceed = false,
                Message = "İlan bulunamadı."
            });
        }
        advert.Description = updateAdvertDto.Description;
        _advertRepository.Update(advert);
        try
        {
            _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($" {ex} İlan güncellenirken bir hata oluştu.");
        }
        return Task.FromResult(new ServiceMassage
        {
            IsSucceed = true,
            Message = "İlan başarıyla güncellendi."
        });

    }
}
