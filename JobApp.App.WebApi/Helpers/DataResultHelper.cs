using JobApp.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobApp.App.WebApi.Helpers
{
    public class DataResultHelper
    {
        public static IDictionary<string, string> GetHeaders(DataQuery value)
        {

            var result = new Dictionary<string, string>();

            result.Add("X-PAGE", value.Pagination.PageNumber.ToString());
            result.Add("X-PAGE_SIZE", value.Pagination.PageSize.ToString());
            result.Add("X-ITEM_COUNT", value.Pagination.ItemCount.ToString());

            if (value.FilterExpressions.Any())
            {
                result.Add("X-FILTER_DATA", Common.Helpers.JsonHelper.Serialize(value.FilterExpressions));
            }

            if (value.SortExpressions.Any())
            {
                result.Add("X-SORT", value.SortExpressions.First().Expression);
                result.Add("X-SORT_DIRECTION", ((int)value.SortExpressions.First().Direction).ToString());

            }

            return result;
        }
    }
}