using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cifcisinden.Data.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cifcisinden.Data.Entities;

public class AdvertEntity : BaseEntity
{

    

    public string Title { get; set; }

    public string Description { get; set; }

    public ServiceCategory ServiceCategory { get; set; }
   
    public Crop? Crop { get; set; }
   
    public City City { get; set; }

    public Town Town { get; set; }

    public string Adress { get; set; }

    public string PhoneNumber { get; set; }

    public int UserId { get; set; }

    //Relational properties
    public UserEntity User { get; set; }
    public ICollection<UserFavoriteAdvertEntity> FavoriteAdverts { get; set; }
}


public class AdvertConfiguration : BaseConfiguration<AdvertEntity>
{
    public override void Configure(EntityTypeBuilder<AdvertEntity> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Crop).IsRequired(false);

        builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
        builder.Property(x => x.ServiceCategory).IsRequired();
        builder.Property(x => x.City).IsRequired();
        builder.Property(x => x.Town).IsRequired();
        builder.Property(x => x.Adress).IsRequired().HasMaxLength(200);
        builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(20);



    }
}