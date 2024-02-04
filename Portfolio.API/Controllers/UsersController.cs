using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Portfolio.API.Dto.User;
using Portfolio.API.Services.Contracts;
using Portfolio.API.Services.Exceptions;

namespace Portfolio.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController(
        IUserService userService, 
        ILogger<UsersController> logger,
        IValidator<CreateUserRequest> createUserValidator) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] UserSearch search)
        {
            List<UserDto> users = await userService.GetAll();

            return Ok(users);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateUserRequest dto)
        {
            var result = await createUserValidator.ValidateAsync(dto);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            logger.LogInformation($"Registering user {dto.UserName}");

            try
            {
                UserDto user = await userService.Create(dto);
                return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
            }
            catch (ConflictException ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            UserDto? user = await userService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
