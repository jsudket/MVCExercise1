using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SportStore.Domain.Abstract;
using SportStore.Domain.Entities;

namespace SportStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _repository;
        public int pageSize = 4;

        public ProductController(IProductRepository productRepository)
        {
            _repository = productRepository;
        }

        public ViewResult List(int page = 1)
        {
            return View(_repository.Products
                            .OrderBy(p => p.ProductID)
                            .Skip((page - 1) * pageSize)
                            .Take(pageSize));
        }
    }
}
