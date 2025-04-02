using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cifcisinden.Data.Entities;

public class BaseEntity
{

    public int Id { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }


    public bool IsDeleted { get; set; }
}


public abstract class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    

    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        //Veri tabanı üzerinde yapılacak tüm sorgularda ve linq sorgularında geçerli olacak bir filtreleme. Softdelete atılmış verileri getirmeyeceğiz. 

        builder.HasQueryFilter(x => x.IsDeleted == false);

        builder.Property(x => x.ModifiedDate).IsRequired(false);

    }
}

public abstract class BaseManyToManyConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(x => x.ModifiedDate).IsRequired(false);
    }
}
