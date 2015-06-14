using EShopDomainModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EShopDomainModel.Concrete
{
    public class Repository<T>:IRepository<T> 
        where T:class,IEntity,new()
    {
        public void Create(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetByPredicate(Guid id)
        {
            throw new NotImplementedException();
        }
        //private readonly DbContext context;
        //public Repository()
        //{
        //    context = new ShopContext();
        //}
        //public void Create(T entity)
        //{
        //    if (entity != null)
        //    {
        //        context.SaveChanges();
        //        context.Set<T>().Add(entity);
        //    }

        //}

        //public void Delete(int id)
        //{
        //    T entity = context.Set<T>().Where(t => t.Id.Equals(id)).FirstOrDefault();
        //    if (entity != null)
        //    {
        //        context.Set<T>().Remove(entity);
        //        context.SaveChanges();
        //    }
        //}

        //public void Update(T entity)
        //{
        //    var tEntity = context.Set<T>().Find(entity.Id);
        //    if(tEntity!=null)
        //    {
        //        var oldEntity = context.Entry(tEntity);
        //        oldEntity.CurrentValues.SetValues(entity);
        //        oldEntity.State = EntityState.Modified;
        //        context.SaveChanges();
        //    }
        //}

        //public IEnumerable<T> GetAll()
        //{
        //    return context.Set<T>();
        //}

        //public T GetByPredicate(Guid id)
        //{
        //    return context.Set<T>().Where(entity => entity.Id.Equals(id)).FirstOrDefault();
        //}
    }
}
