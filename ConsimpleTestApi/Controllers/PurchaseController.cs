using ConsimpleTestApi.BL.Product;
using ConsimpleTestApi.BL.Purchase;
using ConsimpleTestApi.Models.DTO.Product;
using ConsimpleTestApi.Models.DTO.Purchase;
using Microsoft.AspNetCore.Mvc;

namespace ConsimpleTestApi.Controllers
{
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;
        private readonly ILogger<PurchaseController> _logger;

        public PurchaseController(IPurchaseService purchaseService, ILogger<PurchaseController> logger)
        {
            _purchaseService = purchaseService;
            _logger = logger;
        }

        [HttpPost("/purchases")]
        public async Task<IActionResult> Create([FromBody] CreatePurchaseRequest createPurchaseRequest)
        {
            //var validationResult = _validator.Validate(createProductRequest);
            //if (!validationResult.IsValid)
            //    return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

            try
            {
                await _purchaseService.CreateAsync(createPurchaseRequest);
                return Created();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while adding new purchase.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "An unexpected error occurred. Please try again later." });
            }
        }

        [HttpGet("/purchases")]
        public async Task<IActionResult> GetAll()
        {
            //var validationResult = _validator.Validate(createProductRequest);
            //if (!validationResult.IsValid)
            //    return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

            try
            {
                var response = await _purchaseService.GetAllAsync();
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "An unexpected error occurred. Please try again later." });
            }
        }
    }
}
