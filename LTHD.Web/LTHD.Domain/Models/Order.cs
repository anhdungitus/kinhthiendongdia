using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTHD.Domain.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int TotalCost { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhoneNumber { get; set; }
        public string TradeAdress { get; set; }
        public string UserName { get; set; }
        public bool Status { get; set; }
        public DateTime RequestDay { get; set; }
        public ICollection<OrderLine> Lines { get; set; }
    }

    public class OrderLine
    {
        public int OrderLineId { get; set; }
        public int Count { get; set; }

        public int ProductId { get; set; }
        public int OrderId { get; set; }

        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
