using System.Collections.Generic;

namespace LTHD.Web.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}