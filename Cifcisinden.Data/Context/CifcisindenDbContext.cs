using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cifcisinden.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cifcisinden.Data.Context;

public class CifcisindenDbContext : DbContext
{

    public CifcisindenDbContext(DbContextOptions<CifcisindenDbContext> options) : base(options)
    {
        
    }


    public DbSet<UserEntity> Users => Set<UserEntity>();

    public DbSet<AdvertEntity> Adverts => Set<AdvertEntity>();

    public DbSet<UserFavoriteAdvertEntity> UserFavoriteAdverts => Set<UserFavoriteAdvertEntity>();


   


protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new AdvertConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new UserFavoriteAdvertConfiguration());

        modelBuilder.Entity<UserFavoriteAdvertEntity>().HasQueryFilter(x => x.Advert == null || x.Advert.IsDeleted == false);
        //Burada UserFavoriteAdvertEntity tablosuna bir query filter ekledik. Bu filter ile UserFavoriteAdvertEntity tablosundan veri çekerken Advert tablosundan silinmiş olan verileri almamak için bir filtre ekledik.
    }



}