using JobApp.Common.Data;
using JobApp.Data.Contexts;
using JobApp.Interfaces.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace JobApp.Data.Repositories
{
    public abstract class Repository<T, TKey> : Interfaces.Data.Repositories.IRepository<T, TKey> where T : class, new()
    {
        protected JobAppContext Context { get; }
        public Repository(JobAppContext context)
        {
            Context = context;
        }
        public abstract TKey GetKey(T instance);
        public async Task<TKey> Add(T instance)
        {
            Context.Entry(instance).State = EntityState.Added;
            await Context.SaveChangesAsync();
            return GetKey(instance);
        }

        public async Task<bool> Delete(TKey id)
        {
            var instance = await Context.Set<T>().FindAsync(id);
            Context.Entry(instance).State = EntityState.Deleted;
            var result = await Context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> Destroy(TKey id)
        {
            var instance = await Context.Set<T>().FindAsync(id);
            Context.Entry(instance).State = EntityState.Deleted;
            var result = await Context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<T> Get(TKey id)
        {
            var result = await Context.Set<T>().FindAsync(id);
            return result;
        }
        protected virtual void PerformIncludes(ref IQueryable<T> query)
        {
        }
        public async Task<DataResult<T>> Query(DataQuery<T> query)
        {
            await Task.Yield();
            var result = new DataResult<T>();

            result.Query.Pagination = query.Pagination;

            var resultQuery = Context.Set<T>().AsQueryable();
            
            PerformIncludes(ref resultQuery);

            foreach (var filter in query.FilterExpressions)
            {
                switch (filter.Operator)
                {

                    case FilterOperator.Equals:
                        result.Query.FilterExpressions.Add(filter);
                        break;
                    default:
                        result.Query.FilterExpressions.Add(filter);
                        break;
                }

            }

            result.Query.Pagination.SetCount(resultQuery.Count());


            foreach (var sort in query.SortExpressions)
            {
                switch (sort.Expression)
                {
                    default:
                        resultQuery = resultQuery.OrderBy(string.Format("{0} {1:G}", sort.Expression, sort.Direction));
                        result.Query.SortExpressions.Add(sort);
                        break;
                }
            }

            resultQuery = resultQuery.Skip(result.Query.Pagination.Skip).Take(result.Query.Pagination.PageSize);

            result.Items = resultQuery;
            return result;
        }

        public async Task<IQueryable<T>> Query(Action<IQueryable<T>> expression)
        {
            await Task.Yield();
            var query = Context.Set<T>();
            expression(query);
            return query;
        }

        public async Task<bool> Update(T instance)
        {
            Context.Entry(instance).State = EntityState.Modified;
            var result = await Context.SaveChangesAsync();
            return result > 0;
        }
    }
}
