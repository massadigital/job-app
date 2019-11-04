using System;
using System.Collections.Generic;
using System.Text;

namespace JobApp.Common.Data
{

    public class SortExpression
    {
        public SortExpression()
        {
        }

        public SortExpression(SortDirection direction, string attribute)
        {
            Direction = direction;
            Expression = attribute;
        }
        public SortExpression(object direction, string attribute)
        {
            Direction = (SortDirection)Enum.Parse(typeof(SortDirection), direction.ToString());
            Expression = attribute;
        }

        public SortDirection Direction { get; set; } = SortDirection.Asc;
        public string Expression { get; set; }
    }

}
