using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobApp.Common.Helpers;
namespace JobApp.Common.Data
{
    public class DataQuery
    {
        static public DataQuery Create(int page, int pageSize, string sort, int sortDirection, string filterData)
        {
            var result = new DataQuery();
            result.SortExpressions.Add(new SortExpression((SortDirection)sortDirection, sort));
            result.FilterExpressions = JsonHelper.DeserializeOrDefault<List<FilterExpression>>(filterData);
            result.Pagination = new Pagination()
            {
                PageNumber = page,
                PageSize = pageSize
            };
            return result;
        }
        public List<SortExpression> SortExpressions { get; set; } = new List<SortExpression>();
        public List<FilterExpression> FilterExpressions { get; set; } = new List<FilterExpression>();
        public Pagination Pagination { get; set; } = new Pagination();
    }
    public class DataQuery<T> : DataQuery
    {
        static public new DataQuery<T> Create(int page, int pageSize, string sort, int sortDirection, string filterData)
        {
            var result = new DataQuery<T>();
            result.SortExpressions.Add(new SortExpression((SortDirection)sortDirection, sort));
            result.FilterExpressions = JsonHelper.DeserializeOrDefault<List<FilterExpression>>(filterData);
            result.Pagination = new Pagination()
            {
                PageNumber = page,
                PageSize = pageSize
            };
            return result;
        }
    }
}
