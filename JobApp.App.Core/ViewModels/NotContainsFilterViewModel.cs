using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApp.App.Core.ViewModels
{
    public class NotContainsFilterViewModel
    {
        public int[] Subject { get; set; }
        public int[] Filter { get; set; }
        public int[] NotContained { get; set; }
    }
}
