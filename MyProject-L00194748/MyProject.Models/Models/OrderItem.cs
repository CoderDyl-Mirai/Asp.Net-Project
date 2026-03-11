using MyProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public BookDetails Book { get; set; }
        public int QtyOrdered { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
