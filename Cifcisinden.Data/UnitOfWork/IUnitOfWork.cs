using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cifcisinden.Data.UnitOfWork;

public interface IUnitOfWork : IDisposable
{

    Task<int> SaveChangesAsync();
    //Kaç kayda etki ettiğini geriye döner.

    Task BeginTransaction();

    // Task nedir? Asyn metotların voidi gibi düşünülebilir. 

    

    //Transaction işlemlerini onaylar.

    Task RollbackTransaction();
    //Transaction işlemlerini geri alır.

    Task CommitTransactionAsync();
    //Transaction işlemlerini onaylar.









}
