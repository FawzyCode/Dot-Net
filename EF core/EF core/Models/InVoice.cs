using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_core.Models
{
    public class InVoice
    {
        [Key]
        public int Id { get; set; }
        public string CustomerTitle {  get; set; }
        public string CustomerName {  get; set; }
        public string FullName {  get; set; }

        public decimal Price {  get; set; }
        public decimal Qty {  get; set; }
        public decimal Total {  get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
