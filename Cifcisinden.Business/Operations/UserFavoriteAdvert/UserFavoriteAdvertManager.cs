using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cifcisinden.Data.Context;
using Cifcisinden.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cifcisinden.Business.Operations.UserFavoriteAdvert;

public class UserFavoriteAdvertManager : IUserFavoriteAdvertService
{
    private readonly CifcisindenDbContext _db;

    public UserFavoriteAdvertManager(CifcisindenDbContext db)
    {
        _db = db;
    }
    public async Task AddToFavorites(int userId, int advertId)
    {
        
        var favoriteAdvert = new UserFavoriteAdvertEntity
        {
            UserId = userId,
            AdvertId = advertId,
            CreatedDate = DateTime.UtcNow
        };
        await _db.UserFavoriteAdverts.AddAsync(favoriteAdvert);
        await _db.SaveChangesAsync();
    }


    public async Task<IEnumerable<AdvertEntity>> GetUserFavorites(int userId)
    {
        var favoriteAdverts = await _db.UserFavoriteAdverts
            .Where(x => x.UserId == userId)
            .Select(x => x.Advert)
            .ToListAsync();
        return favoriteAdverts;
    }

    public async Task RemoveFromFavorites(int userId, int advertId)
    {
        var favoriteAdvert = await _db.UserFavoriteAdverts
            .FirstOrDefaultAsync(x => x.UserId == userId && x.AdvertId == advertId);
        if (favoriteAdvert != null)
        {
            _db.UserFavoriteAdverts.Remove(favoriteAdvert);
            await _db.SaveChangesAsync();
        }
    }

   
}
