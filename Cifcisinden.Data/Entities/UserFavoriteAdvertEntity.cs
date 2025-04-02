using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cifcisinden.Data.Entities;


//Many to many relation table.
public class UserFavoriteAdvertEntity : BaseEntity
{

    public int UserId { get; set; }
   
    public int AdvertId { get; set; }
   
    //Relational propeties
    public AdvertEntity Advert { get; set; }
    public UserEntity User { get; set; }

}


public class UserFavoriteAdvertConfiguration : BaseManyToManyConfiguration<UserFavoriteAdvertEntity>
{
    public override void Configure(EntityTypeBuilder<UserFavoriteAdvertEntity> builder)
    {
        base.Configure(builder); // BaseManyToManyConfiguration'ı uygula
        builder.Ignore(x => x.Id);
        
        builder.HasKey(ufa => new { ufa.UserId, ufa.AdvertId });

        builder.HasOne(ufa => ufa.User)
               .WithMany(u => u.FavoriteAdverts)
               .HasForeignKey(ufa => ufa.UserId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(ufa => ufa.Advert)
               .WithMany(a => a.FavoriteAdverts)
               .HasForeignKey(ufa => ufa.AdvertId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}
