using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApp.App.Core.ViewModels
{
    public class CollatzTopRankedViewModel
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public int[] TopRanked { get; set; }
    }
}
