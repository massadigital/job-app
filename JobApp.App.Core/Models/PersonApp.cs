using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApp.App.Core.Models
{
    public class PersonApp : TrackedApp
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<ClaimApp> Claims { get; set; }
    }
}
