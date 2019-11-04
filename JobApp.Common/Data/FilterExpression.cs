
namespace JobApp.Common.Data
{ 
    public class FilterExpression
    {

        public FilterOperator Operator { get; set; }

        public string Attribute { get; set; }

        public object Value { get; set; }

    }
}
