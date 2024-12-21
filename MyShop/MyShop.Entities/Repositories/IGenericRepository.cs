using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Entities.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        //_Context.Categories.Include("Product").ToList();
        //_Context.Categories.Where(x=> x.Id==id).ToList();
        IEnumerable<T> GetAll(Expression<Func<T,bool>>?predicate = null, string? includeWord = null);

        //_Context.Categories.Include("Product").ToSingleOrDefault();
        //_Context.Categories.Where(x=> x.Id==id).ToSingleOrDefault();
        T GetFirstOrDefault(Expression<Func<T, bool>>? predicate = null, string? includeWord = null);

        //_Context.Category.Add(category)
        void Add(T entity);

        //_Context.Category.Remove(category)
        void Remove(T entity);

        //_Context.Category.RemoveRange(IEnumerable<category>)
        void RemoveRange(IEnumerable<T> entities);

    }
}
