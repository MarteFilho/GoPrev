using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prev.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Plan> Plans { get; set; }

    }
}
