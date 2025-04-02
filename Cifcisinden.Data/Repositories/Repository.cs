using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Cifcisinden.Data.Context;
using Cifcisinden.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cifcisinden.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {

        private readonly CifcisindenDbContext _db;
        
        private readonly DbSet<TEntity> _dbSet;


        public Repository(CifcisindenDbContext db)
        {
            _db = db;

            _dbSet = _db.Set<TEntity>();
        }


        public void Add(TEntity entity)
        {

            entity.CreatedDate = DateTime.Now;

            _dbSet.Add(entity);

            //_db.SaveChanges();

            
        }

        public void Delete(TEntity entity)
        {
            entity.ModifiedDate = DateTime.Now;

            entity.IsDeleted = true;

            _dbSet.Update(entity);

            //_db.SaveChanges();


            
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);

            Delete(entity);

        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate == null ? _dbSet : _dbSet.Where(predicate);
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(TEntity entity)
        {
            entity.ModifiedDate = DateTime.Now;
            _dbSet.Update(entity);
            //_db.SaveChanges();

        }
    }
}


//_db.SaveChanges(); metodu transaction durumları göz önünde bulunarak UnitOfWork patterni ile yönetilecek. 

//Bu repository patterni ile veritabanı işlemleri yapılacak.

//Repository patterni ile veritabanı işlemleri yapılırken UnitOfWork patterni ile transaction yönetimi yapılacak.

//Transaction nedir? Transaction, bir işlem grubunun tümü veya hiçbiri olarak çalışmasını sağlayan bir işlem türüdür.