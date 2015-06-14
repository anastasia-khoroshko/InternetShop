using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EShopDomainModel.Interfaces
{
    public interface IRepository<T> where T:IEntity
    {
        void Create(T entity);
        void Delete(int id);
        void Update(T entity);
        IEnumerable<T> GetAll();
        T GetByPredicate(Guid id);
    }
}
