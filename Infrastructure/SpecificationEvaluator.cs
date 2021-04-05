using System.Linq;
using Core.Entites;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Infrastructure
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery (IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query=inputQuery;
            if(spec.Criteria!=null)
            {
                query=query.Where(spec.Criteria);
            }
            query=spec.Includes.Aggregate(query,(current,include)=>current.Include(include));
            return query;
        }
    }
}