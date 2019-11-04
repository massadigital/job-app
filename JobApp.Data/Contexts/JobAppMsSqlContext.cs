using JobApp.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApp.Data.Contexts
{
    public class JobAppMsSqlContext:JobAppContext
    {
        public JobAppMsSqlContext()
              : base("JobAppConnection")
        {
        }
    }
}
