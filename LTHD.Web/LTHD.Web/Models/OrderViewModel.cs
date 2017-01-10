using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTHD.Web.Models
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public int TotalCost { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhoneNumber { get; set; }
        public string TradeAdress { get; set; }
        public string UserName { get; set; }
        public bool Status { get; set; }
        public DateTime RequestDay { get; set; }
        public List<OrderLineViewModel> Lines { get; set; }
    }

    public class OrderLineViewModel
    {
        public int OderLineId {get; set;}
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
    }
}