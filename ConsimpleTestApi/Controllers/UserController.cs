using ConsimpleTestApi.BL.User;
using ConsimpleTestApi.Models.DTO.User;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ConsimpleTestApi.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        private readonly IValidator<CreateUserRequest> _validator;

        public UserController(IUserService userService,
            IValidator<CreateUserRequest> validator,
            ILogger<UserController> logger)
        {
            _userService = userService;
            _validator = validator;
            _logger = logger;
        }

        [HttpPost("users")]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest createUserRequest)
        {
            var validationResult = _validator.Validate(createUserRequest);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

            try
            {
                await _userService.CreateAsync(createUserRequest);
                return Created();
            }          
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while register new user.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "An unexpected error occurred. Please try again later." });
            }
        }

        [HttpGet("users/{birthDate:datetime}")]
        public async Task<IActionResult> GetByBirth(DateTime birthDate)
        {
            try
            {
                var response = await _userService.GetUsersByBirthAsync(birthDate);
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "An unexpected error occurred. Please try again later." });
            }
        }

        [HttpGet("users/{days:int}")]
        public async Task<IActionResult> GetRecentCustomersAsync(int days)
        {
            try
            {
                var response = await _userService.GetRecentCustomersAsync(days);
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "An unexpected error occurred. Please try again later." });
            }
        }

        [HttpGet("users/{id:Guid}")]
        public async Task<IActionResult> GetPopularCatagoryAsync(Guid id)
        {
            try
            {
                var response = await _userService.GetPopularCatagoryAsync(id);
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "An unexpected error occurred. Please try again later." });
            }
        }
    }
}
