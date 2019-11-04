using System;
using System.Collections.Generic;
using System.Text;

namespace JobApp.Common.Data
{
    public class Pagination
    {
        private int pageNumber = 1;
        private int pageSize = 10;
        public int PageNumber
        {
            get => pageNumber;

            set
            {
                pageNumber = Math.Max(1, value);
            }
        }
        public int PageSize
        {
            get => pageSize;

            set
            {
                pageSize = Math.Max(1, value);
            }
        }
        public int ItemCount { get; set; }
        public int PageCount { get; set; }
        public void SetCount(int count)
        {
            ItemCount = count;
            PageCount = (int)Math.Ceiling((double)ItemCount / (double)PageSize);
            if (PageNumber > PageCount)
            {
                PageNumber = PageCount;
            }
        }
    }
}
