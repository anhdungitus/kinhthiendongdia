using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LTHD.Domain.Models;
using LTHD.Infrastructure.Interfaces;
using LTHD.Web.Models;

namespace LTHD.Web.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoriesController : ApiController
    {
        private ICategoryRepository _categoryRepository {get; set;}
        public CategoriesController()
        {
            _categoryRepository = (ICategoryRepository)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ICategoryRepository));
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<CategoryViewModel> GetAllCategories()
        {
            return _categoryRepository.All.Select(x => new CategoryViewModel() { 
                CategoryId = x.CategoryId, 
                CategoryName = x.CategoryName
            });
        }
    }
}
