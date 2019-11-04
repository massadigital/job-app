using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApp.Common.Data
{
    public class DataResult<T> : DataQuery<T>
    {
        public DataResult()
        {
            Items = (new List<T>()).AsQueryable();
        }
        public DataResult(DataQuery<T> query)
        {
            Items = (new List<T>()).AsQueryable();
            SortExpressions = query.SortExpressions.ToList();
            FilterExpressions = query.FilterExpressions.ToList();
            Pagination = query.Pagination;
        }
        public IQueryable<T> Items { get; set; }
    }
}
