using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prev.Models
{
    public class PlanHealth
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Company Company { get; set; }
        public List<User> Users { get; set; }
    }
}
