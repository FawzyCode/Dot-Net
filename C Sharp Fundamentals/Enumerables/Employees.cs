using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enumerables
{
    public  class Employees : IEnumerable<PayItems>
    {
        private readonly List<PayItems> _PayItems = new();
        //public string Name {  get; set; }
        public void AddPayItem(string name, int value)
        {
            if (string.IsNullOrEmpty(name)) // is string is null
                throw new ArgumentNullException("name"); //pass exception
             // add name , value to _payitems that typed payitems
            _PayItems.Add(new PayItems { Name = name, Value = value }); 
        }

        public IEnumerator<PayItems> GetEnumerator()
        {
            foreach (var item in _PayItems)
                 yield return item;
           
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
    }
    
}
