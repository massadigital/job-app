using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApp.Common.Data
{
    public class DataQuery
    {
        public List<SortExpression> SortExpressions { get; set; } = new List<SortExpression>();
        public List<FilterExpression> FilterExpressions { get; set; } = new List<FilterExpression>();
        public Pagination Pagination { get; set; } = new Pagination();
    }
    public class DataQuery<T>: DataQuery
    {
    }
}
