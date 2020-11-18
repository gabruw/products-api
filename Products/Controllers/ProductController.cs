using Domain.DTO;
using Domain.Entity;
using Domain.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Products.Utils;
using System.Collections.Generic;

namespace Products.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult All()
        {
            Response<IEnumerable<Product>> response = new Response<IEnumerable<Product>>();

            IEnumerable<Product> products = _productRepository.GetAll();
            response.Data = products;

            return Ok(response);
        }

        [HttpPost]
        [Route("include")]
        public IActionResult Include([FromBody] ProductInclude productInclude)
        {
            Response<Product> response = new Response<Product>();

            Product product = _productRepository.GetByCodigoBarras(productInclude.CodigoBarras);
            if (product != null)
            {
                response.Errors.Add(string.Format("O Código de Barras {0} pertence a outro produto.", productInclude.CodigoBarras));
                return BadRequest(response);
            }

            product = _productRepository.Incluid(productInclude.ToProduct());
            response.Data = product;

            return Ok(response);
        }

        [HttpPut]
        [Route("edit")]
        public IActionResult Edit([FromBody] ProductEdit productEdit)
        {
            Response<Product> response = new Response<Product>();

            Product product = _productRepository.Update(productEdit.ToProduct());
            response.Data = product;

            return Ok(response);
        }

        [HttpDelete]
        [Route("remove")]
        public IActionResult Remove([FromQuery] long codigo)
        {
            Response<Product> response = new Response<Product>();

            Product product = _productRepository.GetbyId(codigo);
            if (product == null)
            {
                response.Errors.Add(string.Format("O Código {0} não está cadastrado.", codigo));
                return BadRequest(response);
            }

            product = _productRepository.Remove(product);
            response.Data = product;

            return Ok(response);
        }
    }
}
