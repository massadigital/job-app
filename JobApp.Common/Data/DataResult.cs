using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApp.Common.Data
{
    public class DataResult<T>
    {
        public DataQuery<T> Query { get; set; } = new DataQuery<T>();
        public DataResult()
        {
            Items = (new List<T>()).AsQueryable();
        }
        public DataResult(DataQuery<T> query)
        {
            Items = (new List<T>()).AsQueryable();
            Query = query;
        }
        public IQueryable<T> Items { get; set; } = (new T[] { }).AsQueryable();
    }
}
