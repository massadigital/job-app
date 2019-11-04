using System;
using System.Collections.Generic;
using System.Text;

namespace JobApp.Common.Data
{
    public enum FilterOperator
    {
        Equals = 0,
        GreaterThan = 1,
        LessThan = 2,
        In = 3,
        Like = 4,
        NotEquals = 5
    }
}
