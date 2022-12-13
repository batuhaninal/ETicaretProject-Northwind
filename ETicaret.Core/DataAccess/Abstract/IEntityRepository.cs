using ETicaret.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.DataAccess.Abstract
{
    // Generic Constraint (Generik Kısıt)

    //class : referans tipli olmalı
    //IEntity : IEntity olabilir veya IEntity tipinden miras almış bir nesne olmalı
    //new() : new'lenebilir olmalı
    public interface IEntityRepository<T> 
        where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T,bool>>? filter = null);
        T Get(Expression<Func<T,bool>> filter);
        void Delete(T entity);
        void Update(T entity);
        void Add(T entity);
    }
}
