using JobApp.Common.Data;
using JobApp.Data.Contexts;
using JobApp.Interfaces.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        public async Task<DataResult<T>> Query(DataQuery<T> query)
        {
            await Task.Yield();
            var result = new DataResult<T>();
            var resultQuery = Context.Set<T>();
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
