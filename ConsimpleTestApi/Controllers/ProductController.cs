using ConsimpleTestApi.BL.Product;
using ConsimpleTestApi.Models.DTO.Product;
using ConsimpleTestApi.Models.DTO.User;
using Microsoft.AspNetCore.Mvc;

namespace ConsimpleTestApi.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpPost("/products")]
        public async Task<IActionResult> Create([FromBody] CreateProductRequest createProductRequest)
        {
            //var validationResult = _validator.Validate(createProductRequest);
            //if (!validationResult.IsValid)
            //    return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

            try
            {
                await _productService.CreateAsync(createProductRequest);
                return Created();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while adding new product.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "An unexpected error occurred. Please try again later." });
            }
        }

        [HttpGet("/products")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _productService.GetAllAsync();
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "An unexpected error occurred. Please try again later." });
            }
        }
    }
}
