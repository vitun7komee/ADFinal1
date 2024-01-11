using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUTODEALERN.Model
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required]
        public DateTime OrderDateTime { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        public virtual Salesman Employee { get; set; }

        [Required]
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }

        [Required]
        public int MenuItemId { get; set; }

        public virtual MenuItem MenuItem { get; set; }

        //[Required]
        //public string Status { get; set; }
    }
}
