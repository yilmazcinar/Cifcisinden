using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cifcisinden.Business.Operations.Advert.Dtos;
using Cifcisinden.Business.Types;

namespace Cifcisinden.Business.Operations.Advert
{
    public interface IAdvertService
    {

        Task<ServiceMassage> AddAdvert(AddAdvertDto advert);

        Task<AdvertDto> GetAdvert(int id);

        Task<List<AdvertDto>> GetAllAdverts();

        Task<ServiceMassage> UpdateAdvert(int id, 
UpdateAdvertDto updateAdvertDto);

        Task<ServiceMassage> DeleteAdvert(int id);

        Task<ServiceMassage> PutAdvert(int id, PutAdvertDto putAdvertDto);

    }
}
 