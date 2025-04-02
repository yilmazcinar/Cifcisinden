using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cifcisinden.Data.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace Cifcisinden.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly CifcisindenDbContext _db;

        private IDbContextTransaction _transaction;

        public UnitOfWork(CifcisindenDbContext db)
        {
            _db = db;
        }


        public async Task BeginTransaction()
        {
            _transaction = await _db.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _transaction.CommitAsync();
        }

        public void Dispose()
        {
           _db.Dispose();

            //Garbage collectora temizlenmesi gerektiğini belirtir.Garbage collector rami temizlerken bu metotları temizler.

            //GC.Collect(); //Garbage collectoru çalıştırır.
            //GC.WaitForPendingFinalizers(); //Garbage collectorun işini bitirmesini bekler.
        }

        public async Task RollbackTransaction()
        {
            await _transaction.RollbackAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
           return await _db.SaveChangesAsync();
        }
    }
}
