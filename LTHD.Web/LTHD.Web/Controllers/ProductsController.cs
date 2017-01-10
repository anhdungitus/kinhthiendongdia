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
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        private IProductRepository _productRepository {get; set;}
        public ProductsController()
        {
            _productRepository = (IProductRepository)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IProductRepository));
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<ProductViewModel> GetAllProducts()
        {
            return _productRepository.All.Select(x => 
                new ProductViewModel() {
                    ProductId = x.ProductId, 
                    ProductName = x.ProductName, 
                    CategoryId = x.CategoryId,
                    Category = x.Category.CategoryName, 
                    Price = x.Price, 
                    Description = x.Description, 
                    ImageUrl = x.ImageUrl
                });
        }

        [Route("{productid}")]
        [HttpGet]
        public ProductViewModel GetProductById(int productid)
        {
            return _productRepository.All.Where(x => 
                x.ProductId == productid).Select(x =>
                        new ProductViewModel()
                        {
                            ProductId = x.ProductId, 
                            ProductName = x.ProductName, 
                            CategoryId = x.CategoryId,
                            Category = x.Category.CategoryName
                }).FirstOrDefault();
        }

        [Route("")]
        [HttpPost]
        [Authorize(Roles="Adminstrators")]
        public async Task<IHttpActionResult> PostNewProduct([FromBody] Product pnew)
        {
            if (ModelState.IsValid)
            {
                await _productRepository.InsertOrUpdate(pnew);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("")]
        [HttpPut]
        [Authorize(Roles = "Adminstrators")]
        public async Task<IHttpActionResult> UpdateProduct([FromBody] Product p)
        {
            //Product pnew = new Product()
            //{
            //    ProductId = p.ProductId, 
            //    CategoryId = p.CategoryId, 
            //    ProductName = p.ProductName
            //};
            if (ModelState.IsValid)
            {
                await _productRepository.InsertOrUpdate(p);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [Route("{id}")]
        [HttpDelete]
        [Authorize(Roles = "Adminstrators")]
        public async Task DeleteProduct(int id)
        {
            await _productRepository.Delete(id);
        }
    }
}
