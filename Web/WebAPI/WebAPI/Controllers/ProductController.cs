using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpPost]
        public IActionResult Create([FromForm] CreateProductDto dto) // Dùng [FromForm] để nhận file
        {
            _service.CreateProduct(dto);
            return Ok(new { message = "Product created successfully" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromForm] CreateProductDto dto)
        {
            _service.UpdateProduct(id, dto);
            return Ok(new { message = "Product updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteProduct(id);
            return Ok(new { message = "Product deleted" });
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _service.GetById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }
    }
}