using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_core.Models
{
    public  class Uniform
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created {  get; set; }
        public int DeliveryOrder {  get; set; }
    }
}
