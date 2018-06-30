using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Store.Services.Products.Dto;
using Store.Services.Products.Repositories;
using Store.Services.Products.Domain;
using System.Linq;

namespace Store.Services.Products.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> Get(Guid id)
        {
            var product = await _productRepository.GetAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(Map(product));
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get() => Ok((await _productRepository.BrowseAsync()).Select(t => Map(t)));

        private ProductDto Map(Product product) => new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Category = product.Category,
            Price = product.Price
        };
    }
}
