using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LTHD.Domain.Models;
using LTHD.Infrastructure.Interfaces;
using LTHD.Web.Models;

using System.Threading.Tasks;

namespace LTHD.Web.Controllers
{
    [RoutePrefix("api/orders")]
    public class OrdersController : ApiController
    {
        private IProductRepository _productRepository { get; set; }
        private IOrderRepository _orderRepository { get; set; }
        private IOrderLineRepository _orderLineRepository { get; set; }
        public OrdersController()
        {
            _productRepository = (IProductRepository)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IProductRepository));
            _orderRepository = (IOrderRepository)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IOrderRepository));
            _orderLineRepository = (IOrderLineRepository)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IOrderLineRepository));
        }

        [Route("")]
        [HttpGet]
        public List<OrderViewModel> GetAllOders()
        {
            return _orderRepository.All.Select(t => new OrderViewModel()
            {
                OrderId = t.OrderId,
                TotalCost = t.TotalCost,
                ReceiverName = t.ReceiverName, 
                ReceiverPhoneNumber = t.ReceiverPhoneNumber, 
                TradeAdress = t.TradeAdress, 
                UserName = t.UserName,
                Status = t.Status,
                RequestDay = t.RequestDay,
                Lines = t.Lines.Select(o => new OrderLineViewModel()
                {
                    Count = o.Count,
                    ProductId = o.ProductId,
                    ProductName = o.Product.ProductName,
                    OderLineId = o.OrderLineId, 
                    Price = o.Product.Price
                }).ToList()
            }).ToList(); 
        }

        [Route("{id}")]
        [HttpGet]
        public IEnumerable<OrderLineViewModel> GetOderLinesByOrderId(int id)
        {
            return _orderLineRepository.All.Where(o => o.OrderId == id).Select(x => new OrderLineViewModel()
            {
                OderLineId = x.OrderId,
                ProductId = x.ProductId,
                ProductName = x.Product.ProductName,
                Count = x.Count
            });
        }

        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> PostNewOrder([FromBody] Order order)
        {
            if (ModelState.IsValid)
            {
                await _orderRepository.InsertOrUpdate(order);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateOrder([FromBody] Order order)
        {
            if (ModelState.IsValid)
            {
                await _orderRepository.InsertOrUpdate(order);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task DeleteOrder(int id)
        {
            await _orderRepository.Delete(id);
        }
    }
}
