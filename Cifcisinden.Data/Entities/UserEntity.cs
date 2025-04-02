using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cifcisinden.Data.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cifcisinden.Data.Entities;

public class UserEntity : BaseEntity
{

    
    public string Email { get; set; }

    public string Password { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime BirthDay { get; set; }

    public City City { get; set; }

    public Town Town { get; set; }

    public string Adress { get; set; }

    public string? PhoneNumber { get; set; }

    public UserType UserType { get; set; }

    public UserStatus UserStatus { get; set; }

    //Relational properties
    public ICollection<AdvertEntity> Adverts { get; set; }
    public ICollection<UserFavoriteAdvertEntity> FavoriteAdverts { get; set; }

}

public class UserConfiguration : BaseConfiguration<UserEntity>
{
    public override void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Password).IsRequired().HasMaxLength(100);
        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
        builder.Property(x => x.BirthDay).IsRequired();
        builder.Property(x => x.City).IsRequired();
        builder.Property(x => x.Town).IsRequired();
        builder.Property(x => x.Adress).IsRequired().HasMaxLength(200);
        builder.Property(x => x.PhoneNumber).IsRequired(false).HasMaxLength(20);
        
        builder.Property(x => x.UserStatus).IsRequired();
    }
}