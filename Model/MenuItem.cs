using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUTODEALERN.Model
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Category { get; set; }

        public virtual ICollection<Order> Orders { get; set; }// Коллекция заказов, связанных с данным блюдом

        public MenuItem()
        {
            Orders = new List<Order>();
        }

    }
}
