using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUTODEALERN.Model
{
    public class Salesman
    {
        public int SalesmanId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]

        public string Position { get; set; }
        public string ContactInfo { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public Salesman()
        {
            Orders = new List<Order>();
        }
   
    }
}
