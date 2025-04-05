using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cifcisinden.Data.Entities;

namespace Cifcisinden.Business.Operations.UserFavoriteAdvert;

public interface IUserFavoriteAdvertService
{
    Task AddToFavorites(int userId, int advertId);
    Task RemoveFromFavorites(int userId, int advertId);
    Task<IEnumerable<AdvertEntity>> GetUserFavorites(int userId);



}
